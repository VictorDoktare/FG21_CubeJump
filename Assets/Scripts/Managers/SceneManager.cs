using UnityEngine;

namespace Managers
{
    public class SceneManager : MonoBehaviour
    {
        public static SceneManager Instance { get; private set; }
        void Awake()
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

        public void LoadScene(int  buildIndex) => UnityEngine.SceneManagement.SceneManager.LoadScene(buildIndex);
    }
}
