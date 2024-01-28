using UnityEngine;

public class PlayerScript : MonoBehaviour, IDamageable
{
    [SerializeField] private KeyCode LeftKey = KeyCode.A;
    [SerializeField] private KeyCode RightKey = KeyCode.D;
    [SerializeField] private KeyCode UpKey = KeyCode.W;
    [SerializeField] private KeyCode DownKey = KeyCode.S;
    [SerializeField] private KeyCode JumpKey = KeyCode.Y;

    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] float FallSpeed;
    
    public Vector2 playerFacingDirection;
    
    private SpriteRenderer _spriteRenderer;
    private PlayerSpecific _playerSpecific;
    private Animator _animator;
    private Rigidbody2D _rigidbody;

    private float _horizontalMovement;
    [SerializeField] private LayerMask groundLayer;

    private void Start()
    {
        _playerSpecific = GetComponent<PlayerSpecific>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerDirection();
        _horizontalMovement = playerFacingDirection.x;

        var animation = "Idle";
        
        if (playerFacingDirection.x != 0)
        {
            animation = "Walk";
        }

        if (Input.GetKeyDown(JumpKey) && is_Grounded())
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, JumpSpeed);
        }

        if (Input.GetKeyUp(JumpKey) && _rigidbody.velocity.y > 0f)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _rigidbody.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(DownKey))
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocityX, FallSpeed);
        }

        if (_rigidbody.velocity.y > 0f)
        {
            animation = "Jump";
        }
        
        _animator.Play(animation);
        
        Flip();
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(_horizontalMovement * MoveSpeed, _rigidbody.velocity.y);
    }

    private bool is_Grounded()
    {
        return Physics2D.OverlapCircle(transform.position, 0.1f, groundLayer);
    }

    private void PlayerDirection()
    {
        Vector2 direction;
        direction.x = Input.GetKey(RightKey) ? 1 : 0;
        direction.x += Input.GetKey(LeftKey) ? -1 : 0;
        
        direction.y = Input.GetKey(UpKey) ? 1 : 0;
        direction.y += Input.GetKey(DownKey) ? -1 : 0;
        
        playerFacingDirection = direction;
    }

    private void Flip()
    {
        var transform1 = transform;
        transform1.localScale = playerFacingDirection.x switch
        {
            < 0f => new Vector3(-1, 1, 1),
            > 0f => Vector3.one,
            _ => transform1.localScale
        };
    }

    public void TakeDamage(bool isLethal)
    {
        if (!isLethal) return;
        switch (_playerSpecific.thisPlayer)
        {
            case PlayerSpecific.Player.Player1:
                ScoreManager.Player2WinRound();
                break;
            case PlayerSpecific.Player.Player2:
                ScoreManager.Player1WinRound();
                break;
            default:
                Debug.Log("Player not valid");
                break;
        }
    }
}