using System;
using System.Collections;
using System.Collections.Generic;
using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace EnemyAI
{
    public class EnemyAIAttackController : MonoBehaviour, IDamageable
    {
        [SerializeField] private float attackSpeed;
        
        private Rigidbody _rb;

        private List<ICar> _targets = new List<ICar>();

        private Enums.Enums.AIState aiState;

        private Coroutine _attackR;
        
         void Awake()
        {
            _rb = GetComponent<Rigidbody>();
            aiState = GetComponent<EnemyAIMovementController>().aiState;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                Attack();
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            aiState = Enums.Enums.AIState.Attacking;
            
            ICar target = other.GetComponent<ICar>();
            
            if (target!=null && !_targets.Contains(target))
            {
                _targets.Add(target);
                
                Attack();

                /*
                if (_attackR == null)
                {
                    _attackR = StartCoroutine(AttackRoutine());
                }*/
            }
        }

        
        private void OnTriggerExit(Collider other)
        {
            ICar target = other.GetComponent<ICar>();

            if (target!=null && _targets.Contains(target))
            {
               // aiState = Enums.Enums.AIState.Moving;
                
                _targets.Remove(target);
            }
        }

        public void Attack()
        {
            if (aiState == Enums.Enums.AIState.Attacking)
            {
                /* Quaternion toRotate = Quaternion.LookRotation(transform.right, Vector3.up);
                _rb.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, attackSpeed * Time.fixedDeltaTime);*/
                transform.DORotate(new Vector3(0f, transform.rotation.y + 90f, 0f), 0.3f).OnComplete((() => {aiState = Enums.Enums.AIState.Moving;}));
            }
        }

        private IEnumerator AttackRoutine()
        {
            while (_targets.Count >0)
            {
                Attack();
                
                yield return null;
            }
            aiState = Enums.Enums.AIState.Moving;

            _attackR = null;
        }

        public void TakeDamage(Collision collision)
        {
            
        }
    }
}
