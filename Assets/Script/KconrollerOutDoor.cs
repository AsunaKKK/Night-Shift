using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KconrollerOutDoor : MonoBehaviour
{
    private float horizontal;
    public float dashSpeed = 5f;
    private float LSpeed = 5f;
    private float RSpeed = 5f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private enum State { idle, walk}
    private State state = State.idle;

    private void Update()
    {
        //MoveMent Player
        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            state = State.walk;

        }
        //movement player R
        else if (horizontal > 0)
        {
            rb.velocity = new Vector2(RSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            state = State.walk;
        }

        anim.SetInteger("state", (int)state);
        AnimationState();
    }

    void AnimationState()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            state = State.walk;
        }
        else
        {
            state = State.idle;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * dashSpeed, rb.velocity.y);
    }
}
