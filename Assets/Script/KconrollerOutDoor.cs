using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KconrollerOutDoor : MonoBehaviour
{
    private float horizontal;
    public float d = 5f;
    private float ls = 5f;
    private float rs = 5f;

    public bool canMove = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    public AudioSource soundWalk;
    bool checksound = true;

    private enum State { idle, walk}
    private State state = State.idle;

    private void OnEnable()
    {
        soundWalk.enabled = false;
    }
    private void Update()
    {
        if (!canMove)
        {
            d = 0f;
            ls = 0f;
            rs = 0f;
            anim.SetInteger("state", 0);
            soundWalk.enabled = false;
        }
        if(!canMove)
        {
            return;
        }
        if(canMove)
        {
            d = 5f;
            ls = 5f;
            rs = 5f;
            //MoveMent Player
            horizontal = Input.GetAxisRaw("Horizontal");

            if (horizontal < 0)
            {
                rb.velocity = new Vector2(-ls, rb.velocity.y);
                transform.localScale = new Vector2(-1, 1);
                state = State.walk;
                checksound = true;
            }
            //movement player R
            else if (horizontal > 0)
            {
                rb.velocity = new Vector2(rs, rb.velocity.y);
                transform.localScale = new Vector2(1, 1);
                state = State.walk;
                checksound = true;

            }
            else
            {
                checksound = false;
            }
        }

        if (checksound == true)
        {
            soundWalk.enabled = true;
        }
        if(checksound == false)
        {
            soundWalk.enabled = false;
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
        rb.velocity = new Vector2(horizontal * d, rb.velocity.y);
    }
    public void CanMoveK(bool canMove)
    {
        this.canMove = canMove;
        state = State.idle;
    }
}
