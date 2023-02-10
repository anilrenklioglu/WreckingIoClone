using UnityEngine;

namespace Enums
{
    public static class Enums 
    {
        public enum AIState
        {
            Moving,
            Attacking
        }
        
        public enum GameState
        {
            MainMenu,
            Playing,
            Finished,
            Lose
        }
    }
}
