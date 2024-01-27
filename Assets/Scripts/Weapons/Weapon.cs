using UnityEngine;

namespace Weapons
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/New Weapon", order = 1)]
    public class Weapon : ScriptableObject
    {
        public GameObject prefab;
        public bool isLethal;
        
        [Header("Throwable")]
        public bool isThrowable;
        public float throwingSpeed;
        public float torque;
    }
}