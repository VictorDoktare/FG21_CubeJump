using UnityEngine;
public class Falling : State
{
    private PlayerController _playerController;
    public Falling(FSMachine stateMachine) : base("Falling", stateMachine)
    {
        _playerController = (PlayerController)StateMachine;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        
        // if (Mathf.Abs(PlayerInput.MoveInput) < Mathf.Epsilon && _playerController.IsGrounded)
        // {
        //     StateMachine.SetState(_playerController.IdleState);
        // }
        // else
        // {
        //     StateMachine.SetState(_playerController.MovingState);
        // }

        if (_playerController.IsGrounded)
        {
            if (Mathf.Abs(PlayerInput.MoveInput) < Mathf.Epsilon)
            {
                StateMachine.SetState(_playerController.IdleState);
            }
            else
            {
                StateMachine.SetState(_playerController.MovingState);
            }
        }
    }
}
