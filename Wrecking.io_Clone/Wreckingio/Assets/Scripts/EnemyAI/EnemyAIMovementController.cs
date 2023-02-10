using System;
using Controllers;
using Interfaces;
using Managers;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


namespace EnemyAI
{
    public class EnemyAIMovementController : MonoBehaviour, ICar
    {
        
        [SerializeField] private float turnSpeed;
        
        [SerializeField] private float moveSpeed;
        
        [SerializeField] private RopeController myRope;
        
        private Rigidbody _rb;

        public Enums.Enums.AIState aiState = Enums.Enums.AIState.Moving;

        private Vector3 _moveTo;

        private bool _canMove;

        private void OnEnable()
        {
            EventManager.GameStarted += CanMove;
        }

        private void OnDisable()
        {
            EventManager.GameStarted -= CanMove;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
           
        }

        private void Start()
        {
           MoveTo();
        }

        private void CanMove()
        {
            _canMove = true;
        }

        private void FixedUpdate()
        {
            Move();
        }   

        private void MoveTo()
        {
           _moveTo = GroundManager.Instance.PointGiver(transform.position.y);
        }
        
        public void Move()
        {
            if (_canMove)
            {
                
            }

            if (GameManager.Instance.gameState != Enums.Enums.GameState.Playing)return;
            
            Turn(_moveTo);

            if (Vector3.Distance(transform.position,_moveTo) < 1f)
            {
                MoveTo();
            }
                    
            transform.position = Vector3.MoveTowards(transform.position, _moveTo, Time.deltaTime * moveSpeed);
            
        }
        
        public void Turn()
        {
          
        }

        public Transform GiveTransform()
        {
            return transform;
        }

        public RopeController GetRopeController()
        {
            return myRope;
        }

        private void Turn(Vector3 newPos)
        {
            Quaternion toRotate = Quaternion.LookRotation(newPos-transform.position, Vector3.up);
            _rb.rotation = Quaternion.RotateTowards(transform.rotation, toRotate, turnSpeed * Time.fixedDeltaTime);
        }
    }
}