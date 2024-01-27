using UnityEngine;

public class TrapScript : MonoBehaviour, IDamageable
{
    // [SerializeField] private BoxCollider2D BC;
    private Rigidbody2D _rigidbody;
    // [SerializeField] private Transform GroundCheck;
    // [SerializeField] private LayerMask GroundLayer;

    // public float FallSpeed = 0f;

    // void Start()
    // {
    //     RB.isKinematic = true;
    //     BC.enabled = true;
    // }

    // void Update()
    // {
    //     RB.velocity = new Vector2(0f, FallSpeed);
    //
    //     if (is_Grounded())
    //     {
    //         RB.isKinematic = true;
    //         BC.isTrigger = true;
    //         FallSpeed = 0f;
    //     }
    // }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out IDamageable damageable))
        {
            damageable.TakeDamage(true);
        }
    }

    // private bool is_Grounded()
    // {
    //     return Physics2D.OverlapCircle(GroundCheck.position, 0.51f, GroundLayer);
    // }

    public void TakeDamage(bool isLethal)
    {
        _rigidbody.gravityScale = 1;

        // RB.isKinematic = false;
        // FallSpeed = -7.5f;
    }
}