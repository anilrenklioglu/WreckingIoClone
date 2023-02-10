using System.Collections.Generic;
using UnityEngine;
using Util_Classes;

namespace Managers
{
    public class EnemyAIManager : SingletonMonobehaviour<EnemyAIManager>
    {
        public List<GameObject> enemyAIList= new List<GameObject>();
        
        public bool ThereIsNoEnemyAI()
        {
            if (enemyAIList.Count == 0)
            {
                return true;
            }

            return false;
        }
        
        public void RemoveAI(GameObject enemyAI)
        {
            if (enemyAIList.Contains(enemyAI))
            {
                enemyAIList.Remove(enemyAI);
            }
        }
    }
}
