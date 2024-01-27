using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class TrapScript : MonoBehaviour, IDamageable
{

    [SerializeField] private BoxCollider2D BC;
    [SerializeField] private Rigidbody2D RB;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;

    public float FallSpeed = 0f;

    // Start is called before the first frame update
    void Start()
    {
      
        RB.isKinematic = true;
        BC.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(0f, FallSpeed);

        if (is_Grounded() == true)
        {
            RB.isKinematic = true;
            BC.isTrigger = true;
            FallSpeed = 0f;
        }
    }

    private bool is_Grounded()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.51f, GroundLayer);
    }

    public void TakeDamage()
    {
        RB.isKinematic = false;
        FallSpeed = -7.5f;
    }
}