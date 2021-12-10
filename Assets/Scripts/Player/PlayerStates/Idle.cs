using FSMachine;

namespace Player.PlayerStates
{
    public class Idle : State
    {
        protected readonly PlayerController PlayerController;
    
        public Idle(FSMachine.FSMachine stateMachine) :  base("Idle", stateMachine)
        {
            PlayerController = (PlayerController)StateMachine;
        }

        public override void Enter()
        {
            base.Enter();
            PlayerInput.MoveInput = 0;
        }

        #region Logic & Physics Update
        public override void UpdateLogic()
        {
            base.UpdateLogic();
            CheckForStateTransition();
        }

        public override void UpdatePhysics()
        {
            base.UpdatePhysics();
            PlayerController.MovePlayer(PlayerInput.MoveInput, 0, 0);
        }

        #endregion
    
        protected virtual void CheckForStateTransition()
        {
            if (PlayerController.IsGrounded)
            {
                if (PlayerInput.JumpInput)
                {
                    StateMachine.SetState(PlayerController.JumpState);
                }
                else if (PlayerInput.MoveInput != 0)
                {
                    StateMachine.SetState(PlayerController.MovingState);
                }
            }
        }
    }
}
