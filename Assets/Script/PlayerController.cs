using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using System.Threading;

public class PlayerController : MonoBehaviour , IDataSave
{
    private float horizontal;
    public float dashSpeed = 5f;
    private float LSpeed = 5f;
    private float RSpeed = 5f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    public Image hpBar;
    public Image energyBar;
    private float maxHp = 100f;
    private float maxEnergy = 100f;
    public float currenHp = 100f;
    public float currenEnergy = 100f;

    private bool canMove = true;

    private bool canDie = false;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;
    //[SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip walkClip;
    //[SerializeField] private AudioClip runClip;
    //[SerializeField] private AudioClip dashClip;

    public static PlayerController instance;

    private enum State { idle,walk,run,dash }
    private State state = State.idle;

    public Image bloodImageOne;
    public Image bloodImageTwo;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        anim.SetBool("DiePlayer", false);
        canDie = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        currenHp = maxHp;
        bloodImageOne.gameObject.SetActive(false);
        bloodImageTwo.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (canDie)
        {
            return;
        }
        if (isDashing || !canMove)
        {
            return;
        }

        if(currenHp == 50)
        {
            bloodImageOne.gameObject.SetActive(true);
        }
        if(currenHp == 25f)
        {
            bloodImageTwo.gameObject.SetActive(true);
        }

        //MoveMent Player
        horizontal = Input.GetAxisRaw("Horizontal");

        //movement player L
        if(horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
            state = State.walk;

        }
        //movement player R
        else if(horizontal > 0)
        {
            rb.velocity = new Vector2(RSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
            state = State.walk;
        }
        //play sound Run
        else
        {
            //audioSource.clip = walkClip;
        }

        //Add Energy
        if(currenEnergy <= maxEnergy)
        {
            currenEnergy += 0.001f+Time.deltaTime;
            if(currenEnergy >= maxEnergy)
            {
                currenEnergy = maxEnergy;
            }
        }

        //Shift is Run
        if(Input.GetKey(KeyCode.LeftShift) & currenEnergy != 0)
        {
            dashSpeed = 10;
            currenEnergy -= 0.005f+Time.deltaTime;
            state = State.run;

            if (currenEnergy <=0)
            {
                currenEnergy=0;
                state = State.walk;
                dashSpeed = 5f;
            }
            //audioSource.clip = runClip;
        }
        else
        {
            dashSpeed = 5f;
        }
        //Dash
        if(currenEnergy >= 50)
        {
            if (Input.GetKeyDown(KeyCode.Space) && canDash)
            {
                currenEnergy -= 50f;
                StartCoroutine(Dash());
                //audioSource.clip = dashClip;
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
    public void ToggleMovement(bool canMove)
    {
        this.canMove = canMove;
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
        state = State.dash;
        yield return new WaitForSeconds(dashingTime);
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
            state = State.walk;
        }
        else
        {
            state = State.idle;
        }
    }

    //Add Item Hp
    public void IncreaseHp(int value)
    {
        if (currenHp >= maxHp)
        {
            currenHp = maxHp;
        }
        else
        {
            currenHp += value;
        }
    }

    //Add Item Energy
    public void IncreaseEnergy(int value)
    {
        if (currenEnergy >= maxEnergy)
        {
            currenEnergy = maxEnergy;
        }
        else
        {
            currenEnergy += value;
        }
    }

    //Add Item MaxHpAndEnergy
    public void IncreaseMpAndHp(int hpValues , int mpValues)
    {
        if(currenHp >= maxHp)
        {
            currenHp = maxHp;
        }
        else
        {
            currenHp += hpValues;
        }

        if(currenEnergy >= maxEnergy)
        {
            currenEnergy = maxEnergy;
        }
        else
        {
            currenEnergy += mpValues;
        }
    }
    //show bar Hp and energy
    void ShowBar()
    {
        hpBar.fillAmount = currenHp / maxHp;
        energyBar.fillAmount = currenEnergy / maxEnergy;
    }
    public void TakeDamage(float damageAmount)
    {

            currenHp -= damageAmount;
        if (currenHp <= 0)
        {
            currenHp = 0;
            //canDie = true;
            StartCoroutine(PlayDeathAnimation());
        }
        else
        {
            // anim.SetTrigger("Hit");
        }
    }
    /*private void Die()
    {
        SceneManager.LoadSceneAsync("Scene02");
    }*/

    private IEnumerator PlayDeathAnimation()
    {
        canDie = true;
        anim.SetBool("DiePlayer",true);
        dashSpeed = 0f;
        LSpeed = 0f;
        RSpeed = 0f;
        currenEnergy = 0;
        currenHp = 0;
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadSceneAsync("Scene02");
    }

    // Save and Load Data
    public void LoadData (GameData data)
    {
        this.transform.position = data.playerPosition;
        this.currenHp = data.playerCurrentHp;
        this.currenEnergy = data.playerCurrentMp;
        this.maxHp = data.playerHpMax;
    }

    public void SaveData (GameData data)
    {
        data.playerPosition = this.transform.position;
        data.playerCurrentHp = this.currenHp;
        data.playerHpMax = this.maxHp;
    }
}
