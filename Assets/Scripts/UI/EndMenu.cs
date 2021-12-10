using Managers;
using UnityEngine;

namespace UI
{
    public class EndMenu : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
    
        private void OnEnable()
        {
            EventManager.Instance.ONPlayerDeath += EndGame;
        }

        private void OnDisable()
        {
            EventManager.Instance.ONPlayerDeath -= EndGame;
        }

        private void EndGame()
        {
            _canvas.enabled = true;
        }
    }
}
