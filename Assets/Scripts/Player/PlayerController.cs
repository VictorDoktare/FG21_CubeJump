using FSMachine;
using Player.PlayerStates;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerController : FSMachine.FSMachine
    {
        [Range(0, 50)][SerializeField] private float _moveSpeed;
        [Range(0, 50)][SerializeField] private float _jumpForce;
        [Range(0, 50)][SerializeField] private float _fallSpeed;
        [SerializeField] private bool _debugPlayer;

        #region Properties

        //Player States
        public Idle IdleState { get; private set; }
        public Moving MovingState { get; private set; }
        public Jump JumpState { get; private set; }
        public Falling FallingState { get; private set; }
    
        //Movement
        public Rigidbody RigidBody { get; set; }
        public float MoveSpeed { get => _moveSpeed; set => _moveSpeed = value; }
        public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    
        //Jumping
        public bool IsGrounded { get; private set; }
        public float FallSpeed { get => _fallSpeed; set => _fallSpeed = value; }

        #endregion
    
        protected override State SetInitialState()
        {
            return IdleState;
        }

        public void MovePlayer(float moveInput, float jumpVelocity, float fallSpeed)
        {
            var moveDirection = new Vector3(moveInput, fallSpeed, 0);
            RigidBody.AddForce(moveDirection, ForceMode.VelocityChange);

            //Clamp velocity to match player move speed
            var velocityX = RigidBody.velocity.x;
            velocityX = Mathf.Clamp(velocityX, -MoveSpeed, MoveSpeed);
        
            RigidBody.velocity = new Vector3(velocityX, jumpVelocity, 0);
        }

        #region Unity Event Functions
        private void Awake()
        {
            IdleState = new Idle(this);
            MovingState = new Moving(this);
            JumpState = new Jump(this);
            FallingState = new Falling(this);

            RigidBody = GetComponent<Rigidbody>();
        }
    
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                IsGrounded = true;
            }
        }
    
        private void OnCollisionExit(Collision other)
        {
            if (other.gameObject.CompareTag("Ground"))
            {
                IsGrounded = false;
            }
        }
        #endregion
    
        #region Player Debugging
        private void OnGUI()
        {
            if (_debugPlayer)
            {
                ShowLabel(new Rect(5,5,300,50), "white", 20, "Current State: ", $"{State.StateName}");
                ShowLabel(new Rect(5,25,300,50), "grey", 20, "Old State: ", $"{GetPrevState()}");

                if (IsGrounded)
                {
                    ShowLabel(new Rect(5,50,200,500), "green", 15, "Grounded: ", $"{IsGrounded.ToString()}");
                }
                else
                {
                    ShowLabel(new Rect(5,50,200,500), "red", 15, "Grounded: ", $"{IsGrounded.ToString()}");
                }
            
                ShowLabel(new Rect(5,65,200,500), "grey", 15, "Move Velocity: ",$"{RigidBody.velocity.x.ToString()}");
                ShowLabel(new Rect(5,80,200,500), "grey", 15, "Jump Velocity: ",$"{RigidBody.velocity.y.ToString()}");
            }
        }
        private void ShowLabel(Rect rectValue, string color, int size, string header, string text)
        {
            GUI.Label(rectValue, $"<size={size}>{header}<color='{color}'>{text}</color></size>"); 
        }
        #endregion
    }
}
