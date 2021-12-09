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
        ReadInput();
    }
    #endregion
    
    private void ReadInput()
    {
        //Move
        if (Mathf.Abs(PlayerInput.MoveInput) > Mathf.Epsilon && _playerController.IsGrounded)
        {
            StateMachine.SetState(_playerController.MovingState);
        }
        
        //Jump
        if (PlayerInput.JumpInput && _playerController.IsGrounded)
        {
            StateMachine.SetState(_playerController.JumpState);
        }
    }
}
