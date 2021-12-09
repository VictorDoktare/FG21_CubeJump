using UnityEngine;

public class Idle : State
{
    private PlayerController _playerController;
    
    public Idle(FSMachine stateMachine) : base("Idle", stateMachine)
    {
        _playerController = (PlayerController)StateMachine;
    }
    
    public override void Enter()
    {
        //Todo Play Idle Anim;
    }

    #region Logic & Physics Update
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        CheckForStateTransition();
    }
    #endregion
    
    private void CheckForStateTransition()
    {
        if (_playerController.IsGrounded)
        {
            if (PlayerInput.MoveInput != 0)
            {
                StateMachine.SetState(_playerController.MovingState);
            }
            
            if (PlayerInput.JumpInput)
            {
                StateMachine.SetState(_playerController.JumpState);
            }
        }
    }
}
