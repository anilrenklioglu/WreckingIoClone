
using Controllers;
using UnityEngine;

namespace Interfaces
{
    public interface ICar 
    {
        void Move();
        void Turn();
        
        Transform GiveTransform();
        RopeController GetRopeController();
    }
}
