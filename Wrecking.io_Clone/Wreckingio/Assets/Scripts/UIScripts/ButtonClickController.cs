using Managers;
using UnityEngine;

namespace UIScripts
{
    public class ButtonClickController : MonoBehaviour
    {
        public void StartButton()
        {
            GameManager.Instance.StartGame();
        }
        
        public void RestartButton()
        {
            GameManager.Instance.RestartGame();
        }
        
        public void QuitButton()
        {
            GameManager.Instance.QuitGame();
        }

        public void NextButton()
        {
            GameManager.Instance.RestartGame();
        }
    }
}
