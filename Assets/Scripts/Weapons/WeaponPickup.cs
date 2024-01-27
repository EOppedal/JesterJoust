using UnityEngine;

namespace Weapons
{
    public class WeaponPickup : MonoBehaviour, IWeaponPickup
    {
        [SerializeField] private Weapon weapon; 
        public Weapon Pickup()
        {
            Debug.Log("Picking up: " + weapon.name);
            return weapon;
        }
    }
}