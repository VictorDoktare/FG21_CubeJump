using UnityEngine;

public class Moving : State
{

    private PlayerController _playerController;
    
    private const float MoveOffset = 0.76456f;

    public Moving(FSMachine stateMachine) : base("Moving", stateMachine)
    {
        _playerController = (PlayerController)StateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //Todo Play Running Anim
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
        MovePlayer();
    }
    #endregion
    
    private void MovePlayer()
    {
        var moveDirection = new Vector3(PlayerInput.MoveInput, 0, 0);
        _playerController.RigidBody.AddForce(moveDirection, ForceMode.VelocityChange);
        
        //Clamp velocity to match player move speed
        var velocity = _playerController.RigidBody.velocity.x;
        velocity = Mathf.Clamp(velocity, -_playerController.MoveSpeed + MoveOffset, _playerController.MoveSpeed - MoveOffset);
        
        _playerController.RigidBody.velocity = new Vector3(velocity, 0, 0);
    }
    
    private void CheckForStateTransition()
    {
        if (_playerController.IsGrounded)
        {
            if (PlayerInput.MoveInput == 0)
            {
                StateMachine.SetState(_playerController.IdleState);
            }
            
            if (PlayerInput.JumpInput)
            {
                StateMachine.SetState(_playerController.JumpState);
            }
        }
    }
}
