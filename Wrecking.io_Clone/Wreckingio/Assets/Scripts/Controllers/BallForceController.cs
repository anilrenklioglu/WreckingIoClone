using System;
using Interfaces;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class BallForceController : MonoBehaviour
    {
       
        [SerializeField] private float attackForce;

        public bool isPlayer;
        private bool _canAttack;

        private void Start()
        {
            _canAttack = false;
        }

        private void OnCollisionEnter(Collision other)
        {
            Rigidbody target = other.transform.GetComponent<Rigidbody>();
           

            if (target.CompareTag("Car"))
            {
                _canAttack = true;
                ApplyForce(target);
                ParticleManager.Instance.SpawnExplosionParticle(other.transform.position);

                /*
                if (isPlayer)
                {
                    Vector3 otherEmojiPos = new Vector3(other.transform.position.x + other.transform.position.y +10f,other.transform.position.y,other.transform.position.z +2f);
                    Vector3 myEmojiPos = new Vector3(myCar.transform.position.x + myCar.transform.position.y +10f,myCar.transform.position.y,myCar.transform.position.z+2f);
                    ParticleManager.Instance.SpawnEmojiParticle(myEmojiPos,otherEmojiPos, myCar, other.transform);
                }
                */
            }
        }

        
        private void OnCollisionExit(Collision other)
        {
            Rigidbody target = other.transform.GetComponent<Rigidbody>();
            
            if (target.CompareTag("Car") || target.CompareTag("Player"))
            {
                _canAttack = true;
            }
        }
        
        private void ApplyForce(Rigidbody target)
        {
            if (!_canAttack) return;
            target.AddForce(transform.forward * attackForce, ForceMode.Impulse);   
            _canAttack = false;
        }
    }
}