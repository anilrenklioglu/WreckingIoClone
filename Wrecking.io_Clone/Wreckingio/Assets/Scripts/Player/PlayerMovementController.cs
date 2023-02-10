using System;
using Controllers;
using Interfaces;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour, ICar
    {
        [SerializeField] private float moveSpeed;
        [SerializeField] private float turnSpeed;
        [SerializeField] private RopeController myRope;
        private Vector3 _acceleration;
    
        public Joystick joystick;

       
        private void Update()
        {
            if (GameManager.Instance.gameState != Enums.Enums.GameState.Playing)return;
            
            if (Mathf.Abs(joystick.Horizontal) > 0.2f || Mathf.Abs(joystick.Vertical) > 0.2f)
            {
                _acceleration.x = joystick.Horizontal;
                _acceleration.z = joystick.Vertical;
            }
            else
            {
                _acceleration = Vector3.zero;
            }
        }

        private void FixedUpdate()
        {
            Move();
        
            if (_acceleration != Vector3.zero)
            {
                Turn();
            }
        }

        public void Move()
        {
            if (GameManager.Instance.gameState != Enums.Enums.GameState.Playing)return;
            
            transform.Translate(moveSpeed * transform.forward  * Time.fixedDeltaTime, Space.World);
        }

        public void Turn()
        {
            Quaternion targetRotation = Quaternion.LookRotation(_acceleration);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
        }

        public Transform GiveTransform()
        {
            return transform;
        }

        public RopeController GetRopeController()
        {
            return myRope;
        }
    }

    
}
