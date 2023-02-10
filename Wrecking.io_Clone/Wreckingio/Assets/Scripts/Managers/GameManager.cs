using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Util_Classes;

namespace Managers
{
    public class GameManager : SingletonMonobehaviour<GameManager>
    {
        public Enums.Enums.GameState gameState;
        
        private void Start()
        {
            gameState = Enums.Enums.GameState.MainMenu;
        }
        
        public void StartGame()
        {
            EventManager.OnGameStarted();
            gameState = Enums.Enums.GameState.Playing;
        }
        
        public void FinishGame()
        {
            if (EnemyAIManager.Instance.ThereIsNoEnemyAI())
            {
                EventManager.OnLevelFinished();
                gameState = Enums.Enums.GameState.Finished;
            }
        }
        
        public void FailGame()
        {
            EventManager.OnLevelFailed();
            gameState = Enums.Enums.GameState.Lose;
            Debug.Log(gameState);
        }
        
        public void QuitGame()
        {
            Application.Quit();
            Debug.Log("-----------------Quit Game-----------------");
        }
        
        public void RestartGame()
        {
            //restart the scene
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}