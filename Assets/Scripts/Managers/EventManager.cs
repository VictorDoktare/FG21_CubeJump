using System;
using UnityEngine;

namespace Managers
{
    public class EventManager : MonoBehaviour
    {
        public static EventManager Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(Instance);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    
        public event Action ONPlayerDeath;
        public void PlayerDeath() => ONPlayerDeath?.Invoke();
    
        public event Action ONScore;
        public void Score() => ONScore?.Invoke();
    
    }
}
