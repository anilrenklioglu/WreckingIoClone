using UnityEngine;

namespace Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(Collision collision);
    }
}