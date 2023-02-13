using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    private float dashSpeed = 8f;
    public float LSpeed;
    public float RSpeed;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip Runclip;

    private enum State { idle, run }
    private State state = State.idle;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //MoveMent Player
        horizontal = Input.GetAxisRaw("Horizontal");

        if(horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            state = State.run;
        }
        else if(horizontal > 0)
        {
            rb.velocity = new Vector2(RSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            state = State.run;
        }
        //play sound Run
        else
        {
            AudioSource.clip = Runclip;
        }

        //Dash
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
        {
            StartCoroutine(Dash());
        }

        anim.SetInteger("state", (int)state);
        AnimationState();

    }

    private void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        rb.velocity = new Vector2(horizontal * dashSpeed, rb.velocity.y);
    }

    //Dasd 
    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }


    //Animation Controller
    void AnimationState()
    {
        if (Mathf.Abs(rb.velocity.y) > 0.1f)
        {
            state = State.run;
        }
        else
        {
            state = State.idle;
        }
    }
}
