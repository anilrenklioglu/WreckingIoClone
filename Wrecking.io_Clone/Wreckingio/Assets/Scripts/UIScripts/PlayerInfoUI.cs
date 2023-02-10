using System;
using UnityEngine;

namespace UIScripts
{
    public class PlayerInfoUI : MonoBehaviour
    {
        [SerializeField] private Transform target;
        private void Update()
        {
            if (target !=null)
            {
                transform.position = target.position;
            }
        }
    }
}
