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
        CheckForStateTransition();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        MovePlayer();
    }

    private void MovePlayer()
    {
        var moveDirection = new Vector3(PlayerInput.MoveInput, -_playerController.FallSpeed, 0);
        _playerController.RigidBody.AddForce(moveDirection, ForceMode.VelocityChange);
        
        // //Clamp velocity to match player move speed
        var velocityX = _playerController.RigidBody.velocity.x;
        Mathf.Clamp(velocityX, -_playerController.MoveSpeed, _playerController.MoveSpeed);
    }

    private void CheckForStateTransition()
    {
        if (_playerController.IsGrounded)
        {
            StateMachine.SetState(_playerController.IdleState);
        }
    }
}
