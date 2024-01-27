using UnityEngine;

public class King : MonoBehaviour, IDamageable
{
    public void TakeDamage(bool isLethal)
    {
        if (!isLethal) return;
        // TODO: kill the king
        Debug.Log("King is dead");
    }
}
