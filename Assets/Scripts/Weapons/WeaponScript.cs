using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour, IWeaponPickup
    {
        [SerializeField] private Weapon weapon; 
        
        public Weapon Pickup()
        {
            Debug.Log("Picking up: " + weapon.name);
            return weapon;
        }
        
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