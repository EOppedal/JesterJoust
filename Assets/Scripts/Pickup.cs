using UnityEngine;
using Weapons;

public class Pickup : MonoBehaviour
{
    [SerializeField] private KeyCode pickupKey = KeyCode.R;
    [SerializeField] private GameObject inTriggerIndicator;
    
    private UseWeapons _useWeapons;
    private IPickupWeapon _weapon;
    private bool _isInTrigger;

    private void Start()
    {
        _useWeapons = GetComponent<UseWeapons>();
    }
    
    private void Update()
    {
        if (Input.GetKeyDown(pickupKey) && _isInTrigger && _useWeapons.currentWeapon == null)
        {
            _useWeapons.currentWeapon = _weapon.PickupWeapon();
            inTriggerIndicator.SetActive(false);
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPickupWeapon weapon))
        {
            _weapon = weapon;
            _isInTrigger = true;
            inTriggerIndicator.SetActive(true);
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent(out IPickupWeapon weapon))
        {
            _weapon = null;
            _isInTrigger = false;
            inTriggerIndicator.SetActive(false);
        }
    }
}