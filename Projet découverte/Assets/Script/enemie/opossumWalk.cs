using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opossumWalk : MonoBehaviour
{
    public float walkSpeed;

    [HideInInspector]
    public bool  mustPatrol;
    [SerializeField] 
    private LayerMask m_WhatIsGround;
    [SerializeField]
    private Transform m_GroundCheck;
    [SerializeField]
    Collider2D checkWall;

    Rigidbody2D opossumrigidbody2D;

    Vector3 m_Velocity = Vector3.zero;
    bool facingLeft;
    const float k_GroundedRadius = .2f;
    bool mustTurn;


    void Start()
    {
        mustPatrol = true;
        facingLeft = true;
        opossumrigidbody2D = GetComponent<Rigidbody2D>();
        walkSpeed = -walkSpeed;
    }


    void Update()
    {
        if (mustPatrol)
        {
            Patrol();
        }

    }

    private void FixedUpdate()
    {
        if (mustPatrol)
        {
            mustTurn = !Physics2D.OverlapCircle(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);
        }
    }

    void Patrol()
    {
        if (mustTurn || checkWall.IsTouchingLayers(m_WhatIsGround))
        {
            Flip();
        }

        Vector3 targetVelocity = new Vector2(walkSpeed, opossumrigidbody2D.velocity.y);
        opossumrigidbody2D.velocity = Vector3.SmoothDamp(opossumrigidbody2D.velocity, targetVelocity, ref m_Velocity, 0.5f);
    }

    void Flip()
    {
        if (facingLeft)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        facingLeft = !facingLeft;
        walkSpeed = -walkSpeed;
    }
}
