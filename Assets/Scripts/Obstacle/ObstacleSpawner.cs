using System.Collections;
using Managers;
using UnityEngine;

namespace Obstacle
{
    public class ObstacleSpawner : MonoBehaviour
    {
        [Header("Spawn Settings")]
        [Range(0, 10)][SerializeField] private float _spawnColdown;
        [SerializeField] private Transform[] _destinationPoints;

        #region Unity Event Functions
        private void Start()
        {
            StartCoroutine(nameof(Spawn));
        }
        #endregion

        IEnumerator Spawn()
        {
            while (true)
            {
                yield return new WaitForSeconds(_spawnColdown);

                var obstacle = PoolManager.Instance.GetPooledObject();
            
                if (obstacle != null)
                {
                    obstacle.transform.position = gameObject.transform.position;

                    var randomPos = Random.Range(0, _destinationPoints.Length);
                    var moveDir = (_destinationPoints[randomPos].transform.position - obstacle.transform.position);
                    obstacle.GetComponent<ObstacleController>().MoveDirection = moveDir;
                
                    obstacle.SetActive(true);

                    PoolManager.Instance.InactiveCount--;
                    PoolManager.Instance.ActiveCount++;
                }
            }
            // ReSharper disable once IteratorNeverReturns
        }
    }
}
