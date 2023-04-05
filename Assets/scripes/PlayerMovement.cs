using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sr;
    private BoxCollider2D coll;

    [SerializeField] private LayerMask jumpableGround;

    private float x = 0f;
    [SerializeField] private float MovementSpeed = 8f;
    [SerializeField] private float JumpingPower = 14f;

    private enum MovementState {idel,running,jumping,falling};
    [SerializeField] private AudioSource jumpsound;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(x * MovementSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpsound.Play();
            rb.velocity = new Vector2(rb.velocity.x, JumpingPower);
        }

        RunningAnimation();
    }
    private void RunningAnimation()
    {
        MovementState state;
        if (x > 0f)
        {
            state = MovementState.running;
            sr.flipX = false;
        }
        else if (x < 0f)
        {
            state = MovementState.running;
            sr.flipX=true;
        }
        else
        {
            state = MovementState.idel;
        }
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down,0.1f, jumpableGround);
    }
}