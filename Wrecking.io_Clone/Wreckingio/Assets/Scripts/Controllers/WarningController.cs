using System;
using System.Collections;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class WarningController : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private Animator _animator;

        [SerializeField] private float t;
        [SerializeField] private float dT;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animator = GetComponent<Animator>();
        }
        
        public void Warning()
        {
            if (GameManager.Instance.gameState != Enums.Enums.GameState.Playing)return;
            StartCoroutine(WarningRoutine());
        }

        private IEnumerator WarningRoutine()
        {
            _animator.enabled = true;
            yield return new WaitForSeconds(t);
            _animator.SetTrigger("Fall");
            Invoke(nameof(Fall),dT);
        }

        private void StopFalling()
        {
            _rigidbody.isKinematic = true;
            StopAllCoroutines();
        }
        private void Fall()
        {
           // _rigidbody.isKinematic = false;
            Destroy(gameObject,dT);
        }
    }
}
