using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Script : MonoBehaviour
{
    public float MoveSpeed;
    public float JumpSpeed;

    private float Horizontal;
    private bool IsFacingRight = true;
    private bool MovingRight = false;
    private bool MovingLeft = false;

    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Horizontal = 1f;
            MovingRight = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            Horizontal = -1f;
            MovingLeft = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            MovingRight = false;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            MovingLeft = false;
        }

        if (MovingRight == false && MovingLeft == false && is_Grounded())
        {
            Horizontal = 0f;
        }

        if (Input.GetKeyDown(KeyCode.W) && is_Grounded())
        {
            RB.velocity = new Vector2(RB.velocity.x, JumpSpeed);
        }

        if (Input.GetKeyUp(KeyCode.W) && RB.velocity.y > 0f)
        {
            RB.velocity = new Vector2(RB.velocity.x, RB.velocity.y * 0.5f);
        }

        Flip();
    }

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(Horizontal * MoveSpeed, RB.velocity.y);
    }

    private bool is_Grounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.2f, GroundLayer);
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
}
