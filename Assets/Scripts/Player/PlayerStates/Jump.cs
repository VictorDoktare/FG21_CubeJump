using UnityEngine;

namespace Player.PlayerStates
{
    public class Jump : Moving
    {
        public Jump(FSMachine.FSMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            StateName = "Jump";
            PlayerController.RigidBody.AddForce(Vector3.up * PlayerController.JumpForce, ForceMode.VelocityChange);
        }
    
        #region Logic & Physics Update

        public override void UpdatePhysics()
        {
            PlayerController.MovePlayer(PlayerInput.MoveInput, PlayerController.RigidBody.velocity.y, 0);
        }

        #endregion
    
        protected override void CheckForStateTransition()
        {
            if (PlayerController.RigidBody.velocity.y < -0.25f)
            {
                StateMachine.SetState(PlayerController.FallingState);
            }
        }
    }
}
