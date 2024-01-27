using UnityEngine;

public class Damageable : MonoBehaviour
{

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage()
    {
        Debug.Log("Player dead", gameObject);
        _spriteRenderer.color = Color.red;
    }
}