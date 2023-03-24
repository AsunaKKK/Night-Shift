using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour
{
    private float horizontal;
    public float dashSpeed = 45;
    private float LSpeed = 5f;
    private float RSpeed = 5f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float maxEnergy = 100f;
    public float currenEnergy;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (isDashing)
        {
            return;
        }

        //MoveMent Player
        horizontal = Input.GetAxisRaw("Horizontal");

        //movement player L
        if (horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);

        }
        //movement player R
        else if (horizontal > 0)
        {
            rb.velocity = new Vector2(RSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        //play sound Run
        else
        {
            //audioSource.clip = walkClip;
        }

        //Add Energy
        if (currenEnergy <= maxEnergy)
        {
            currenEnergy += Time.deltaTime;
            if (currenEnergy >= maxEnergy)
            {
                currenEnergy = maxEnergy;
            }
        }

        //Shift is Run
        if (Input.GetKey(KeyCode.LeftShift) & currenEnergy != 0)
        {
            dashSpeed = 48;
            currenEnergy -= 0.01f + Time.deltaTime;

            if (currenEnergy <= 0)
            {
                currenEnergy = 0;
                dashSpeed = 45;
            }
        }
        else
        {
            dashSpeed = 45f;
        }
        //Dash
        if (currenEnergy >= 50)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDash)
            {
                currenEnergy -= 50f;
                StartCoroutine(Dash());
            }
        }
        if (currenEnergy <= 50)
        {
            canDash = false;
        }
        else
        {
            canDash = true;
        }
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

        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

}
