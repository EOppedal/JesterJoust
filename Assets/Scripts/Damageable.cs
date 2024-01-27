using UnityEngine;

public class Damageable : MonoBehaviour
{
    public void TakeDamage()
    {
        Debug.Log("Player dead", gameObject);
    }
}