using UnityEngine;
using Weapons;

namespace Weapons
{
    public class WeaponPickup : MonoBehaviour, IPickupWeapon
    {
        [SerializeField] private Weapon weapon; 
        public Weapon PickupWeapon()
        {
            Debug.Log("Picking up: " + weapon.name);
            return weapon;
        }
    }
}