using System;
using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Vector3 offset;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            offset = _camera.transform.position - player.position;
        }

        private void LateUpdate()
        {
            if (player !=null)
            {
                _camera.transform.position = offset + player.position;
            }
        }
    }
}
