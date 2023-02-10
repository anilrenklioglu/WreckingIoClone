using System;
using System.Collections;
using Controllers;
using UnityEngine;
using UnityEngine.AI;
using Util_Classes;
using Random = UnityEngine.Random;

namespace Managers
{
    public class GroundManager : SingletonMonobehaviour<GroundManager>
    {
        [SerializeField] private float processTime;
        [SerializeField] private GameObject newGround;
        [SerializeField] private float rate;
        private float _scale;
        private Coroutine _warningCoroutine;
        private WarningController _groundToDestroy;
        
       
        protected override void Awake()
        {
            base.Awake();
            FixScale();
        }

        private void Start()
        {
            Processor();
        }
        private void FixScale()
        {
            _groundToDestroy = GetComponentInChildren<WarningController>();
            _scale = (_groundToDestroy.transform.localScale.x / 2) - 1;
        }

        public Vector3 PointGiver(float height)
        {
            Vector3 newPoint = Random.insideUnitSphere * _scale;
            
            newPoint.y = height;

            return newPoint;
        }
       
       private void Processor()
       {
           StartCoroutine(WarningProcess());
       }
      

       private IEnumerator WarningProcess()
       {
           float t = processTime;

           while (t > 0)
           {
               t -= Time.deltaTime;
               yield return null;
           }

           _groundToDestroy.Warning();
           Vector3 newGroundPosition = _groundToDestroy.transform.position;
           _groundToDestroy.transform.localPosition -= Vector3.up * 0.02f;
           GameObject newArea = Instantiate(newGround, newGroundPosition, Quaternion.identity);

           newArea.transform.SetParent(transform);
           newArea.transform.SetSiblingIndex(0);
           if (_scale < 0)
           {
               _scale *= -1;
           }
           newArea.transform.localScale = new Vector3((_scale +1) * 2 *rate , 1, (_scale+1) * 2*rate);
           
           FixScale();
           Processor();
       }
    }
}
