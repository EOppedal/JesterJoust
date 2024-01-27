using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/New Weapon", order = 1)]
    public class Weapon : ScriptableObject
    {
        public GameObject prefab;
        public float weight;
        
        [Header("Throwable")]
        public bool isThrowable;
        public float throwingSpeed;
        public float throwingDamage;
        
        [Header("Melee")]
        public bool isMelee;
        public float meleeDamage;
        public float reach;
        public float attackSpeed;
    }
}