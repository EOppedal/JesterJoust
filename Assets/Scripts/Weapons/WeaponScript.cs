using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour, IWeaponPickup
    {
        [SerializeField] private Weapon weapon; 
        
        public Weapon Pickup()
        {
            Debug.Log("Picking up: " + weapon.name);
            StartCoroutine(RemovePickup());
            return weapon;
        }

        private IEnumerator RemovePickup()
        {
            yield return null;
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(weapon.isLethal);
                Destroy(gameObject);
            }
            else
            {
                gameObject.layer = LayerMask.NameToLayer("Default");
                GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                GetComponent<Collider2D>().isTrigger = true;
            }
        }
    }
}