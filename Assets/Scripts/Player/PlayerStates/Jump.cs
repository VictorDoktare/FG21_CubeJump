using UnityEngine;

public class Jump : State
{
    private PlayerController _playerController;
    
    private Vector3 _moveDirection;
    private bool _isMoving;
    
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

        if (_playerController.RigidBody.velocity.y < 0)
        {
            StateMachine.SetState(_playerController.FallingState);
        }
    }

    #endregion
}
