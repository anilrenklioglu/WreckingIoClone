using System;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class RopeController : MonoBehaviour
    {
        private Transform _firstParent;

        [SerializeField] private MeshRenderer myRope;
        [SerializeField] private BallController ballController;

        private void Awake()
        {
            _firstParent = transform.parent;
        }

        private void Start()
        {
            transform.SetParent(RopeManager.Instance.transform);
            
            _firstParent.gameObject.SetActive(false);
        }
        
        public void CloseRope()
        {
            ballController.CloseBall();
            myRope.enabled = false;
        }
        
        public void OpenRope()
        {
            ballController.OpenBall();
            myRope.enabled = true;
        }
    }
}
