using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class OceanKillController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Kill(other, other.transform.position);
        }

        private void Kill(Collider other, Vector3 position)
        {
            ParticleManager.Instance.SpawnWaterSplashParticle(position);
            Destroy(other.gameObject, 1f);
            EnemyAIManager.Instance.RemoveAI(other.gameObject);
            GameManager.Instance.FinishGame();
        }
        
        
    }
}
