using UnityEngine;

namespace Weapons
{
    public class UseWeapon : MonoBehaviour
    {
        [SerializeField] private KeyCode throwKey = KeyCode.T;
        
        private PlayerScript _playerScript;
        private PlayerSpecific _playerSpecific;
        public Weapon currentWeapon;
        public GameObject holdingWeapon;
        
        private Animator _animator;
        
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
            _animator = GetComponent<Animator>();
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(throwKey))
            {
                Throw();
            }
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
                _playerScript.playerFacingDirection = Vector2.right * transform.localScale.x;
            }
            
            _animator.Play("Throw");
            
            var o = Instantiate(currentWeapon.prefab, transform.position + (Vector3.up * 0.75f), Quaternion.identity);
            o.transform.Rotate(0, 0, Vector2.Angle(transform.up, _playerScript.playerFacingDirection));
            o.layer = _playerSpecific.projectileLayer;
            
            var rb = o.GetComponent<Rigidbody2D>();
            rb.velocity = _playerScript.playerFacingDirection * currentWeapon.throwingSpeed;
            rb.AddTorque(currentWeapon.torque);
            
            currentWeapon = null;
            holdingWeapon.GetComponent<Renderer>().enabled = false;
        }
    }
}