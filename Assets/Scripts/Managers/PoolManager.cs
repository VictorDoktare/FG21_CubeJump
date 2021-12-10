using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {
        public static PoolManager Instance { get; private set; }
    
        [Header("Pool Settings")]
        [SerializeField] private GameObject _poolPrefab;
        [Range(1, 1000)][SerializeField] private int amountToPool;
        public int InactiveCount;
        public int ActiveCount;

        private List<GameObject> _pool;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetPool();
        }

        private void SetPool()
        {
            _pool = new List<GameObject>();
            GameObject obstacle;
        
            for (int i = 0; i < amountToPool; i++)
            {
                obstacle = Instantiate(_poolPrefab);
                obstacle.SetActive(false);
                InactiveCount++;
                _pool.Add(obstacle);
            }
        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < amountToPool; i++)
            {
                if (!_pool[i].activeInHierarchy)
                {
                    return _pool[i];
                }
            }
            return null;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(5, 80, 200, 500),
                $"<size=15>Active pool count: <color='green'>{ActiveCount}</color></size>");
            GUI.Label(new Rect(5, 95, 200, 500),
                $"<size=15>Active pool count: <color='red'>{InactiveCount}</color></size>"); 
        }
    }
}
