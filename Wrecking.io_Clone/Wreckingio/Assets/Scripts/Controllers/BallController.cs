using System;
using UnityEngine;

namespace Controllers
{
    public class BallController : MonoBehaviour
    {
        private Collider _collider;
        private MeshRenderer _meshRenderer;

        private void Awake()
        {
            _collider = GetComponent<Collider>();
            _meshRenderer = GetComponent<MeshRenderer>();
        }

        public void OpenBall()
        {
            _collider.enabled = true;
            _meshRenderer.enabled = true;
        }
        
        public void CloseBall()
        {
            _collider.enabled = false;
            _meshRenderer.enabled = false;
        }
    }
}
