using System;
using Award;
using Interfaces;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Controllers
{
    public class AwardController : MonoBehaviour
    {
        [SerializeField] private GameObject box;
        [SerializeField] private AwardBallRotate awardBallRotate;
        [SerializeField] private float t;
        private BoxCollider _collider;

        private RopeController _carRope;
        private void Awake()
        {
            _collider = GetComponent<BoxCollider>();
        }

        private void Start()
        {
            Invoke(nameof(GiveBox),Random.Range(5,10));
        }

        private void GiveAward(ICar car)
        {
            _carRope = car.GetRopeController();
            _carRope.CloseRope();
            awardBallRotate.SetCar(car.GiveTransform());
            awardBallRotate.transform.SetParent(null);
            awardBallRotate.gameObject.SetActive(true);
            Invoke(nameof(CloseBall),t);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Car") || other.CompareTag("Player"))
            {
                _collider.enabled = false;
                
                ICar car = other.GetComponent<ICar>();
                
                GiveAward(car);
                
                box.SetActive(false);
                
                //play particle
            }
        }
        
        private void GiveBox()
        {
            if (GameManager.Instance.gameState != Enums.Enums.GameState.Playing) return;
            
            _collider.enabled = true;
            box.SetActive(true);
            transform.position = GroundManager.Instance.PointGiver(transform.position.y);
        }
        
        private void CloseBall()
        {
            awardBallRotate.gameObject.SetActive(false);
            _carRope.OpenRope();
        }
    }
}
