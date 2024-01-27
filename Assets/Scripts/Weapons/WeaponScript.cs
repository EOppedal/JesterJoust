using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage();
            }
            Destroy(gameObject);
        }
    }
}