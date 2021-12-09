using UnityEngine;
using UnityEngine.PlayerLoop;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : FSMachine
{
    [Range(0, 20)][SerializeField] private float _moveSpeed;
    [Range(0, 20)][SerializeField] private float _jumpForce;
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

    #endregion

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
            ShowLabel(new Rect(5,5,200,50), "white", 25, State.Name);

            if (IsGrounded)
            {
                ShowLabel(new Rect(5,35,200,500), "green", 15, $"Grounded: {IsGrounded.ToString()}");
            }
            else
            {
                ShowLabel(new Rect(5,35,200,500), "red", 15, $"Grounded: {IsGrounded.ToString()}");
            }
            
            ShowLabel(new Rect(5,55,200,500), "white", 15, $"Move Velocity: {RigidBody.velocity.x.ToString()}");
            ShowLabel(new Rect(5,75,200,500), "white", 15, $"Jump Velocity: {RigidBody.velocity.y.ToString()}");
        }
    }
    private void ShowLabel(Rect rectValue, string color, int size, string text)
    {
        GUI.Label(rectValue, $"<color='{color}'><size={size}>{text}</size></color>"); 
    }
    #endregion

    protected override State SetInitialState()
    {
        return IdleState;
    }
}
