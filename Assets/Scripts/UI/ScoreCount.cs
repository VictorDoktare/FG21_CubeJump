using Managers;
using TMPro;
using UnityEngine;

namespace UI
{
    public class ScoreCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;
        private int _score = 0;

        #region Unity Event Functions
        private void OnEnable()
        {
            EventManager.Instance.ONScore += UpdateScore;
        }

        private void OnDisable()
        {
            EventManager.Instance.ONScore -= UpdateScore;
        }
        #endregion

        private void UpdateScore()
        {
            _score++;
            _text.text = _score.ToString();
        }
    }
}
