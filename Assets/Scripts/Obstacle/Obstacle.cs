using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [Range(0, 20)][SerializeField] private float _moveSpeed;
    [Range(0, 20)][SerializeField] private float _rotationSpeed;
    
    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveObstacle();
        RotateObstacle();
    }

    private void MoveObstacle()
    {
        var velocity = _moveSpeed * Vector3.back;
        _rigidbody.AddForce(Vector3.back, ForceMode.VelocityChange);
        
        Mathf.Clamp(velocity.z, -_moveSpeed, _moveSpeed);
        _rigidbody.velocity = velocity;
    }

    private void RotateObstacle()
    {
        _rigidbody.AddTorque(Vector3.right * 0.01f, ForceMode.VelocityChange);
        _rigidbody.AddTorque(Vector3.forward * _rotationSpeed/1000, ForceMode.VelocityChange);
    }
}
