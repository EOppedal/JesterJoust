using UnityEngine;

public class TrapScript : MonoBehaviour, IDamageable
{
    private Rigidbody2D _rigidbody;
    private bool _hasFallen;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable) && _hasFallen)
        {
            damageable.TakeDamage(true);
            Destroy(gameObject);
        }
    }

    public void TakeDamage(bool isLethal)
    {
        _hasFallen = true;
        _rigidbody.gravityScale = 1;
        _rigidbody.velocity = Vector3.zero;
    }
}