using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class PoolManager : MonoBehaviour
    {

        [Header("Pool Settings")]
        [SerializeField] private GameObject _poolPrefab;
        [Range(1, 1000)][SerializeField] private int amountToPool;
        [SerializeField] private bool _debugPool;

        private List<GameObject> _pool;
        
        #region Properties
        public static PoolManager Instance { get; private set; }
        public int InactiveCount { set; get; }
        public int ActiveCount { set; get; }
        #endregion

        #region Unity Event Fuctions
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
        
        private void OnGUI()
        {
            if (_debugPool)
            {
                GUI.Label(new Rect(5, 80, 200, 500),
                    $"<size=15>Active pool count: <color='green'>{ActiveCount}</color></size>");
                GUI.Label(new Rect(5, 95, 200, 500),
                    $"<size=15>Active pool count: <color='red'>{InactiveCount}</color></size>"); 
            }
        }
        #endregion

        private void SetPool()
        {
            _pool = new List<GameObject>();
            GameObject obstacle;
        
            for (int i = 0; i < amountToPool; i++)
            {
                obstacle = Instantiate(_poolPrefab, GameObject.Find("PooledObjects").transform, true);
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
    }
}
