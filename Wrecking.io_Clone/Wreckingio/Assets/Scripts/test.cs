using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
   private Rigidbody rb;

   public float force;
   public float radius;

   private void Awake()
   {
      rb = GetComponent<Rigidbody>();
   }

   private void OnTriggerEnter(Collider other)
   {
        Rigidbody target = other.GetComponent<Rigidbody>();
    
        if (target != null)
        {
             Add(target);
        }
   }

   private void Add(Rigidbody target)
   {
     // rb.AddExplosionForce(force, transform.position, radius, 0f, ForceMode.Impulse);
      
     target.AddForce(transform.forward * force, ForceMode.Impulse);
   }
}
