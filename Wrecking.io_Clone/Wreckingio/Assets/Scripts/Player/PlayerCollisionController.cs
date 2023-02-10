using System;
using Interfaces;
using Managers;
using UnityEngine;
using Util_Classes;

namespace Player
{
    public class PlayerCollisionController : SingletonMonobehaviour<PlayerCollisionController>, IDamageable, IAttacker
    {
        
        protected override void Awake()
        {
            base.Awake();
            
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Water"))
            {
                GameManager.Instance.FailGame();
            }
        }

        public void TakeDamage(Collision collision)
        {
            throw new System.NotImplementedException();
        }

        public void Attack()
        {
            
        }
    }
}
