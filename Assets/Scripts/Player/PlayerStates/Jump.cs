using UnityEngine;

public class Jump : State
{
    private PlayerController _playerController;

    public Jump(FSMachine stateMachine) : base("Jump", stateMachine)
    {
        _playerController = (PlayerController)StateMachine;
    }

    #region Logic & Physics Update
    public override void Enter()
    {
        base.Enter();
        _playerController.RigidBody.AddForce(Vector3.up * _playerController.JumpForce, ForceMode.VelocityChange);
        //Todo Play Jump Anim;
    }

    public override void UpdatePhysics()
    {
        base.Enter();
        CheckForStateTransition();
        MovePlayer();
    }

    #endregion
    
    private void MovePlayer()
    {
        var moveDirection = new Vector3(PlayerInput.MoveInput,0, 0);
        _playerController.RigidBody.AddForce(moveDirection, ForceMode.VelocityChange);
        //
        // //Clamp velocity to match player move speed
        var velocityX = _playerController.RigidBody.velocity.x;
        velocityX = Mathf.Clamp(velocityX, -_playerController.MoveSpeed, _playerController.MoveSpeed);
        
        _playerController.RigidBody.velocity = new Vector3(velocityX,  _playerController.RigidBody.velocity.y, 0);
    }

    private void CheckForStateTransition()
    {
        if (_playerController.RigidBody.velocity.y < -0.25f)
        {
            StateMachine.SetState(_playerController.FallingState);
        }
    }
}
