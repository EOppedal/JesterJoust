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
                Melee();
            }
            
            if (Input.GetKeyDown(throwKey))
            {
                Throw();
            }
        }
        
        private void Melee()
        {
            if (currentWeapon == null || !currentWeapon.isMelee)
            {
                Log("Can't melee");
                return;
            }
            
            Log("Melee attack");
            
            // var o = Instantiate(currentWeapon.prefab, transform.position, Quaternion.identity);
            // var a = o.GetComponent<Animator>();
            // a.speed = currentWeapon.attackSpeed;
            // a.Play("Attack");
        }
        
        private void Throw()
        {
            if (currentWeapon == null || !currentWeapon.isThrowable)
            {
                Log("Can't throw");
                return;
            }

            if (_playerScript.playerFacingDirection == Vector2.zero)
            {
                _playerScript.playerFacingDirection = Vector2.right;
            }

            var o = Instantiate(currentWeapon.prefab, transform.position + (Vector3.up * 0.5f), Quaternion.identity);
            o.transform.Rotate(0, 0, Vector2.Angle(transform.up, _playerScript.playerFacingDirection));
            o.layer = _playerSpecific.projectileLayer;
            o.GetComponent<Rigidbody2D>().velocity = _playerScript.playerFacingDirection * currentWeapon.throwingSpeed;
            
            currentWeapon = null;
        }
    }
}