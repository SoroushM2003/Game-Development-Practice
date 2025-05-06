using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public float Jump;
    public Transform GroundCheck;
    public LayerMask GroundLayer;
    public float GroundRadius;
    public Animator Anim;

    private float MoveX;
    private bool IsGrounded;
    public bool FacingRight = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
    }

    void Update()
    {
        IsGrounded = Physics2D.OverlapCircle(GroundCheck.position, GroundRadius, GroundLayer);

        MoveX = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(MoveX * Speed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.velocity = Vector2.up * Jump;
        }

        if ((MoveX > 0 && !FacingRight) || (MoveX < 0 && FacingRight))
        {
            Flip();
        }

        Anim.SetBool("isGrounded", IsGrounded);
        Anim.SetFloat("velocityX", rb.velocity.x);
        Anim.SetFloat("velocityY", rb.velocity.y);
    }

    void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}