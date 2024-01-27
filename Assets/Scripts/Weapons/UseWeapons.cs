using System;
using System.Collections;
using UnityEngine;

namespace Weapons
{
    public class UseWeapons : MonoBehaviour
    {
        [SerializeField] private Weapon currentWeapon;
        [SerializeField] private KeyCode hitKey = KeyCode.R;
        [SerializeField] private KeyCode throwKey = KeyCode.T;

        private Player1Script player1Script;
        
        [Header("Debug")]
        [SerializeField] private bool isDebugging;

        private void Log(string message)
        {
            if (isDebugging) Debug.Log(message);
        }

        private void Start()
        {
            player1Script = GetComponent<Player1Script>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(hitKey))
            {
                Hit();
            }
            
            if (Input.GetKeyDown(throwKey))
            {
                Throw();
            }
        }

        private void Hit()
        {
            if (!currentWeapon.isMelee)
            {
                Log("Weapon can't melee");
                return;
            }
            
            Log("Hit");
        }
        
        private void Throw()
        {
            if (!currentWeapon.isThrowable)
            {
                Log("Weapon can't be thrown");
                return;
            }
            
            var o = Instantiate(currentWeapon.prefab, transform.position, Quaternion.identity);
            o.GetComponent<Rigidbody2D>().velocity = transform.right * currentWeapon.throwingSpeed;
            
            StartCoroutine(ThrownWeapon(o));
            
            Log("Throw weapon");
        }
        
        private static IEnumerator ThrownWeapon(GameObject gameObject)
        {
            // RemoveCurrentWeapon();
            yield return new WaitForSeconds(0.25f);
            gameObject.GetComponent<Collider2D>().enabled = true;
            yield return new WaitForSeconds(1.5f);
            Destroy(gameObject);
        }

        private void RemoveCurrentWeapon()
        {
            currentWeapon = null;
        }
    }
}