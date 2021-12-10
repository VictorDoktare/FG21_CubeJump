using Managers;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleController : MonoBehaviour
    {
        [Range(0, 20)][SerializeField] private float _moveSpeed;
        [Range(0, 20)][SerializeField] private float _rotationSpeed;
        [Range(0, 20)][SerializeField] private float _lifeTime;
    
        private Rigidbody _rigidbody;
        private float _timer;

        public Vector3 MoveDirection { get; set; }
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        private void OnEnable()
        {
            _timer = _lifeTime;
        }

        private void FixedUpdate()
        {
            MoveObstacle();
            RotateObstacle();
            CheckLifetime();
        }
    
        private void MoveObstacle()
        {
            var velocity = _moveSpeed * Vector3.back;
            _rigidbody.AddForce(MoveDirection, ForceMode.VelocityChange);
        
            Mathf.Clamp(velocity.z, -_moveSpeed, _moveSpeed);
            _rigidbody.velocity = velocity;
        }

        private void RotateObstacle()
        {
            _rigidbody.AddTorque(Vector3.right * 0.01f, ForceMode.VelocityChange);
            _rigidbody.AddTorque(Vector3.forward * _rotationSpeed/1000, ForceMode.VelocityChange);
        }

        private void CheckLifetime()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0)
            {
                gameObject.SetActive(false);
            
                PoolManager.Instance.InactiveCount++;
                PoolManager.Instance.ActiveCount--;
            }
        }
    }
}
