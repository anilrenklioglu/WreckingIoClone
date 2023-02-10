using UnityEngine;
using Util_Classes;

namespace Managers
{
    public class ParticleManager : SingletonMonobehaviour<ParticleManager>
    {
        [SerializeField] private GameObject waterSplashParticle;
        [SerializeField] private GameObject happyEmojiParticle;
        [SerializeField] private GameObject sadEmojiParticle;
        [SerializeField] private GameObject explosionParticle;
        public void SpawnWaterSplashParticle(Vector3 position)
        {
           GameObject splash = Instantiate(waterSplashParticle, position, Quaternion.identity);
           
           splash.GetComponent<ParticleSystem>().Play();
           
           Destroy(splash,1f);
        }
        
        public void SpawnEmojiParticle(Vector3 position, Vector3 targetPosition, Transform parent, Transform targetParent)
        {
            GameObject emoji = Instantiate(happyEmojiParticle, position, Quaternion.identity);
            emoji.GetComponent<ParticleSystem>().Play();
            emoji.transform.SetParent(parent);
            Destroy(emoji,1f);
            GameObject emoji2 = Instantiate(sadEmojiParticle, targetPosition, Quaternion.identity);
            emoji2.GetComponent<ParticleSystem>().Play();
            emoji2.transform.SetParent(targetParent);
            Destroy(emoji2,1f);
        }
        
        public void SpawnExplosionParticle(Vector3 position)
        {
            GameObject explosion = Instantiate(explosionParticle, position, Quaternion.identity);
            explosion.GetComponent<ParticleSystem>().Play();
            Destroy(explosion,1f);
        }
        
        
        
    }
}
