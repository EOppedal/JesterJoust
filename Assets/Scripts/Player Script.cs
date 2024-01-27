using UnityEngine;

public class PlayerScript : MonoBehaviour, IDamageable
{
    [SerializeField] private KeyCode LeftKey = KeyCode.A;
    [SerializeField] private KeyCode RightKey = KeyCode.D;
    [SerializeField] private KeyCode UpKey = KeyCode.W;
    [SerializeField] private KeyCode DownKey = KeyCode.S;
    [SerializeField] private KeyCode JumpKey = KeyCode.Y;

    public float MoveSpeed;
    public float JumpSpeed;
    public float FallSpeed;
    
    public Vector2 playerFacingDirection;
    
    private SpriteRenderer _spriteRenderer;
    private PlayerSpecific _playerSpecific;

    private float Horizontal;
    private bool IsFacingRight = true;
    private bool MovingRight = false;
    private bool MovingLeft = false;

    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private BoxCollider2D BC;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    private void Start()
    {
        _playerSpecific = GetComponent<PlayerSpecific>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        PlayerDirection();
        
        if (Input.GetKeyDown(RightKey))
        {
            Horizontal = 1f;
            MovingRight = true;
        }
        if (Input.GetKeyDown(LeftKey))
        {
            Horizontal = -1f;
            MovingLeft = true;
        }

        if (Input.GetKeyUp(RightKey))
        {
            MovingRight = false;
        }
        if (Input.GetKeyUp(LeftKey))
        {
            MovingLeft = false;
        }

        if (MovingRight == false && MovingLeft == false && is_Grounded())
        {
            Horizontal = 0f;
        }

        if (Input.GetKeyDown(JumpKey) && is_Grounded())
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpSpeed);
        }

        if (Input.GetKeyUp(JumpKey) && RB.velocity.y > 0f)
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
        }

        if (Input.GetKeyDown(DownKey))
        {
            RB.velocity = new Vector2(RB.velocityX, FallSpeed);
        }
        
        Flip();
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

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(Horizontal * MoveSpeed, RB.velocity.y);
    }

    private bool is_Grounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 1.1f, GroundLayer);
    }

    private void Flip()
    {
        if (IsFacingRight == true && Horizontal < 0f || IsFacingRight == false && Horizontal > 0f)
        {
            IsFacingRight = !IsFacingRight;
            Vector3 tempScale = transform.localScale;
            tempScale.x *= -1f;
            transform.localScale = tempScale;
        }
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

        // Debug.Log("Player dead", gameObject);
        // _spriteRenderer.color = Color.red;
    }
}