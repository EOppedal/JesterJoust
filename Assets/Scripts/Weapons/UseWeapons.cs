using UnityEngine;

namespace Weapons
{
    public class UseWeapons : MonoBehaviour
    {
        [Header("Controls")]
        [Tooltip("Key for melee hitting with weapon")] [SerializeField] private KeyCode hitKey = KeyCode.R;
        [Tooltip("Key for throwing weapon")] [SerializeField] private KeyCode throwKey = KeyCode.T;
        
        private PlayerScript _playerScript;
        private PlayerSpecific _playerSpecific;
        public Weapon currentWeapon;
        
        #region ---Debugging---
        [Header("Debug")]
        [SerializeField] private bool isDebugging;

        private void Log(string message)
        {
            if (isDebugging) Debug.Log(message);
        }
        #endregion
        
        private void Start()
        {
            _playerScript = GetComponent<PlayerScript>();
            _playerSpecific = GetComponent<PlayerSpecific>();
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
            if(currentWeapon == null) return;
            if (!currentWeapon.isMelee)
            {
                Log("Weapon can't melee");
                return;
            }
            
            Log("Hit");
        }
        
        private void Throw()
        {
            if(currentWeapon == null) return;
            if (!currentWeapon.isThrowable)
            {
                Log("Weapon can't be thrown");
                return;
            }
            
            var o = Instantiate(currentWeapon.prefab, transform.position, Quaternion.identity);
            o.layer = _playerSpecific.projectileLayer;
            
            o.GetComponent<Rigidbody2D>().velocity = transform.right * currentWeapon.throwingSpeed * _playerScript.playerFacingDirection;
            
            RemoveCurrentWeapon();
            
            Log("Throw weapon");
        }
        
        private void RemoveCurrentWeapon()
        {
            currentWeapon = null;
        }
    }
}