using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float horizontal;
    public float dashSpeed = 8f;
    private float LSpeed = 8f;
    private float RSpeed = 8f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public Image hpBar;
    public Image energyBar;
    private float maxHp = 100f;
    private float maxEnergy = 100f;
    public float currenHp;
    public float currenEnergy;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private TrailRenderer tr;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip Runclip;

    private enum State { idle, run }
    private State state = State.idle;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        currenHp = maxHp;
        currenEnergy = maxEnergy;
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
        if(horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            state = State.run;
        }
        //movement player R
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

        //Add Energy
        if(currenEnergy <= maxEnergy)
        {
            currenEnergy += Time.deltaTime;
            if(currenEnergy >= maxEnergy)
            {
                currenEnergy = maxEnergy;
            }
        }

        //Shift is Run
        if(Input.GetKey(KeyCode.LeftShift) & currenEnergy != 0)
        {
            dashSpeed = 15;
            currenEnergy -= 0.01f+Time.deltaTime;
            if(currenEnergy <=0)
            {
                currenEnergy=0;
            }

        }
        else
        {
            dashSpeed = 8f;
        }
        //Dash
        if(currenEnergy >= 50)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDash)
            {
                currenEnergy -= 50f;
                StartCoroutine(Dash());
            }
        }
        if(currenEnergy <= 50)
        {
            canDash = false;
        }
        else
        {
            canDash = true;
        }

        anim.SetInteger("state", (int)state);
        AnimationState();
        ShowBar();


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

    void ShowBar()
    {
        hpBar.fillAmount = currenHp / maxHp;

        energyBar.fillAmount = currenEnergy / maxEnergy;
    }
}
