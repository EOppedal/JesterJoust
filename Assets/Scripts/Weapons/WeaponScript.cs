using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class WeaponScript : MonoBehaviour
    {
        [SerializeField] private float despawnTime;
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.TryGetComponent(out Damageable damageable))
            {
                damageable.TakeDamage();
            }
            
            StartCoroutine(Despawn());
        }
        
        private IEnumerator Despawn()
        {
            yield return new WaitForSeconds(despawnTime);
            Destroy(gameObject);
        }
    }
}