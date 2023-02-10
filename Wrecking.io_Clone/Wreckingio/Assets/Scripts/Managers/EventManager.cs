using UnityEngine;

namespace Managers
{
    public static class EventManager
    {
        public delegate void GameStartDelegate();
        public static event GameStartDelegate GameStarted;
        public static void OnGameStarted() => GameStarted?.Invoke();
        
        public delegate void LevelFailedDelegate();
        public static event LevelFailedDelegate LevelFailed;
        public static void OnLevelFailed() => LevelFailed?.Invoke();
        
        public delegate void LevelFinishedDelegate();
        public static event LevelFinishedDelegate LevelFinished;    
        public static void OnLevelFinished() => LevelFinished?.Invoke();
    }
}