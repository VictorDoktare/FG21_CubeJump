namespace Player.PlayerStates
{
    public class Moving : Idle
    {
        public Moving(FSMachine.FSMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            StateName = "Moving";
        }
    
        protected override void CheckForStateTransition()
        {
            if (PlayerController.IsGrounded)
            {
                if (PlayerInput.JumpInput)
                {
                    StateMachine.SetState(PlayerController.JumpState);
                }
                else if (PlayerInput.MoveInput == 0)
                {
                    StateMachine.SetState(PlayerController.IdleState);
                }
            }
        }
    }
}
