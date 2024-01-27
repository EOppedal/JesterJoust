using UnityEngine;
using Weapons;

public class Interact : MonoBehaviour
{
    [SerializeField] private KeyCode interactKey = KeyCode.E;
    [SerializeField] private GameObject inTriggerIndicator;
    
    private UseWeapon _useWeapon;
    private IWeaponPickup _weapon;
    private IDoor _door;
    private bool _isInWeaponTrigger;
    private bool _isInInteractTrigger;

    private void Start()
    {
        _useWeapon = GetComponent<UseWeapon>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(interactKey) && _isInWeaponTrigger && _useWeapon.currentWeapon == null)
        {
            _useWeapon.currentWeapon = _weapon.Pickup();
            inTriggerIndicator.SetActive(false);
        }
        
        if (Input.GetKeyDown(interactKey) && _isInInteractTrigger)
        {
            transform.position = _door.Enter();
            inTriggerIndicator.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IWeaponPickup intractable))
        {
            _weapon = intractable;
            _isInWeaponTrigger = true;
            inTriggerIndicator.SetActive(true);
        }
        
        if (other.TryGetComponent(out IDoor door))
        {
            _door = door;
            _isInInteractTrigger = true;
            inTriggerIndicator.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IWeaponPickup intractable))
        {
            _weapon = null;
            _isInWeaponTrigger = false;
            inTriggerIndicator.SetActive(false);
        }
        
        if (other.TryGetComponent(out IDoor door))
        {
            _door = null;
            _isInInteractTrigger = false;
            inTriggerIndicator.SetActive(false);
        }
    }
}