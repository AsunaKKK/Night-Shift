using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMap : MonoBehaviour , IDataSave
{
    private float horizontal;
    public float dashSpeed;
    private float LSpeed = 30f;
    private float RSpeed = 30f;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;

    private float maxEnergy = 100f;
    public float currentEnergy;

    private CheckWall wall;

    [SerializeField] private Rigidbody2D rb;

    public RectTransform rectTransform;
    private Vector3 savedPosition;
    private Quaternion savedRotation;


    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        currentEnergy = maxEnergy;
        wall = FindObjectOfType<CheckWall>();
    }

    void Update()
    {
        if (isDashing)
        {
            return;
        }

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal < 0)
        {
            rb.velocity = new Vector2(-LSpeed, rb.velocity.y);
            transform.localScale = new Vector2(-1, 1);
        }
        else if (horizontal > 0)
        {
            rb.velocity = new Vector2(RSpeed, rb.velocity.y);
            transform.localScale = new Vector2(1, 1);
        }
        else
        {
            //audioSource.clip = walkClip;
        }

        if (currentEnergy <= maxEnergy)
        {
            currentEnergy += 0.001f + Time.deltaTime;
            if (currentEnergy >= maxEnergy)
            {
                currentEnergy = maxEnergy;
            }
        }

        CheckDash();

        if (currentEnergy >= 50 && Input.GetKeyDown(KeyCode.Space) && canDash)
        {
            currentEnergy -= 50f;
            StartCoroutine(Dash());
        }

        if (currentEnergy <= 50)
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

        rb.velocity = new Vector3(horizontal * dashSpeed, rb.velocity.y);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        rb.velocity = new Vector3(transform.localScale.x * dashingPower, 0f);

        yield return new WaitForSeconds(dashingTime);

        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);

        canDash = true;
    }

    public void CheckDash()
    {
        if (Input.GetKey(KeyCode.LeftShift) && currentEnergy != 0)
        {
            dashSpeed = wall.checkWalls ? 0f : 70f;
            currentEnergy -= 0.005f + Time.deltaTime;

            if (currentEnergy <= 0)
            {
                currentEnergy = 0;
                dashSpeed = wall.checkWalls ? 0f : 30f;
            }
        }
        else
        {
            dashSpeed = wall.checkWalls ? 0f : 30f;
            LSpeed = wall.checkWalls ? 0f : 30f;
            RSpeed = wall.checkWalls ? 0f : 30f;
        }
    }

    public void SaveData(GameData data)
    {
        data.playerMapPosition = savedPosition;
        data.playerMapRotation = savedRotation;

    }

    public void LoadData(GameData data)
    {
        savedPosition = data.playerMapPosition;
        savedRotation = data.playerMapRotation;

        // Set the position and rotation after loading
        /*rectTransform.position = savedPosition;
        rectTransform.rotation = savedRotation;*/
    }


}
