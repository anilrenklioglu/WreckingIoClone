using System;
using UnityEngine;
using DG.Tweening;

namespace Award
{
    public class AwardBallRotate : MonoBehaviour
    {
        [SerializeField] private float rotateTime;

       private Transform _car;


       private void OnEnable()
       {
           RotateBall();
       }

       private void Update()
       {
           StayInOrbit();
       }

       public void SetCar(Transform orbit)
       {
           _car = orbit;
       }
       
       public void CloseBall()
       {
           gameObject.SetActive(false);
       }

       private void StayInOrbit()
       {
           if (_car == null) return;
           {
               Vector3 pos = _car.position;
                pos.y = transform.position.y;
                transform.position = pos;
           }
       }

       public void RotateBall()
       {
           transform.DORotate(new Vector3(0f, 360f, 0f), rotateTime, RotateMode.FastBeyond360)
               .SetEase(Ease.Linear)
               .SetLoops(-1,LoopType.Incremental);
       }
    }
}
