using UnityEngine;
using Weapons;

namespace Weapons
{
    public class WeaponPickup : MonoBehaviour, IPickupWeapon
    {
        [SerializeField] private Weapon weapon; 
        public Weapon PickupWeapon()
        {
            Debug.Log("PickupWeapon");
            return weapon;
        }
    }
}

public interface IPickupWeapon
{
    public Weapon PickupWeapon();
}