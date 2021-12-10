namespace Player.PlayerStates
{
    public class Falling : Jump
    {
        public Falling(FSMachine.FSMachine stateMachine) : base(stateMachine) { }
    
        public override void Enter()
        {
            StateName = "Falling";
        }

        public override void UpdateLogic()
        {
            base.UpdateLogic();
            CheckForStateTransition();
        }

        public override void UpdatePhysics()
        {
            PlayerController.MovePlayer(PlayerInput.MoveInput, PlayerController.RigidBody.velocity.y, -PlayerController.FallSpeed);
        }
    
        protected override void CheckForStateTransition()
        {
            if (PlayerController.IsGrounded)
            {
                StateMachine.SetState(PlayerController.IdleState);
            }
        }
    }
}
