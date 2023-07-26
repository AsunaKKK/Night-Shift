using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour
{
    public Waypoint[] wayPoints;
    public float speed = 5f;
    public bool isCircular;
    public bool inReverse = true;
    public bool canWalk = true;
    public float runRange = 2f;
    public string playerTag = "Player";
    public Transform attackRange; // Reference to the transform representing the attack range

    private Waypoint currentWaypoint;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float originalSpeed;
    private float attackCooldown = 2f;
    private bool isAttacking = false;

    private bool isChasingPlayer = false;
    private Transform playerTransform;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private enum State { Idle, Walk, Run, Attack }
    private State state = State.Idle;

    private void Start()
    {
        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
        originalSpeed = speed;

        // Get the Animator component attached to the enemy
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        UpdateAnimation(state);
        if (canWalk && !isChasingPlayer && currentWaypoint != null && !isWaiting && !isAttacking)
        {
            // Check if the player is within range
            if (playerTransform != null && Vector3.Distance(transform.position, playerTransform.position) < runRange)
            {
                // Call the Run function if the player is within range
                Run(playerTransform.position);
            }
            else
            {
                // Move towards the current waypoint if the player is not within range
                MoveTowardsWaypoint();
            }
        }
        else if (isChasingPlayer)
        {
            // Move towards the player if we are chasing them
            MoveTowardsPlayer();
        }

        // Update the attack cooldown timer
        if (isAttacking)
        {
            attackCooldown -= Time.deltaTime;
            state = State.Attack;
            if (attackCooldown <= 0f)
            {
                isAttacking = false;
                attackCooldown = 2f;
            }
        }
    }

    private void Pause()
    {
        isWaiting = !isWaiting;
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 targetPosition = currentWaypoint.transform.position;
        targetPosition.y = transform.position.y;
        targetPosition.z = transform.position.z;

        if (Vector3.Distance(transform.position, targetPosition) > 0.1f)
        {
            Vector3 directionOfTravel = (targetPosition - transform.position).normalized;
            transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
            anim.SetBool("IsWalking", true); // Play walk animation
            state = State.Walk;
        }
        else
        {
            if (currentWaypoint.waitSeconds > 0)
            {
                Pause();
                Invoke("Pause", currentWaypoint.waitSeconds);
            }

            if (currentWaypoint.speedOut > 0)
            {
                speed = currentWaypoint.speedOut;
            }
            else if (speed != originalSpeed)
            {
                speed = originalSpeed;
            }

            NextWaypoint();
            state = State.Idle;
        }
        }

        private void NextWaypoint()
    {
        if (isCircular)
        {
            if (!inReverse)
            {
                currentIndex = (currentIndex + 1 >= wayPoints.Length) ? 0 : currentIndex + 1;
            }
            else
            {
                currentIndex = (currentIndex == 0) ? wayPoints.Length - 1 : currentIndex - 1;
            }
        }
        else
        {
            if ((!inReverse && currentIndex + 1 >= wayPoints.Length) || (inReverse && currentIndex == 0))
            {
                inReverse = !inReverse;
            }
            currentIndex = (!inReverse) ? currentIndex + 1 : currentIndex - 1;
        }

        currentWaypoint = wayPoints[currentIndex];

        
    }

    private void Run(Vector3 playerPosition)
    {
        // Set the speed to a higher value for running
        speed = 8f;

        // Start chasing the player
        isChasingPlayer = true;
        playerTransform = GameObject.FindGameObjectWithTag(playerTag).transform;

        state = State.Run;

    }

    private void MoveTowardsPlayer()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) > 0.1f)
        {
            Vector3 directionOfTravel = (playerTransform.position - transform.position).normalized;
            transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
            anim.SetBool("IsWalking", true); // Play walk animation while chasing the player
        }
        else
        {
            // Stop chasing the player when we reach their position
            isChasingPlayer = false;
            speed = originalSpeed;
            currentWaypoint = wayPoints[currentIndex];

            // Attack the player when within the attack range
            Vector3 distanceToPlayer = playerTransform.position - transform.position;
            if (distanceToPlayer.magnitude < attackRange.localScale.x)
            {
                AttackPlayer();
            }
        }
        state = State.Run;
    }

    // Implement the attack logic here, for example, using a raycast or collision detection with the player
    // When the enemy successfully hits the player, set isAttacking to true to trigger the attack cooldown
    // You can call this function from an attack animation event or any other appropriate place in your game logic
    private void AttackPlayer()
    {
        if (!isAttacking)
        {
            // Perform attack action here
            isAttacking = true;

            // Reduce the player's health using the PlayerController script
            PlayerController playerController = playerTransform.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.TakeDamage(10); // Replace 10 with the amount of damage you want the enemy's attack to deal
            }

            // Start the attack cooldown
            StartCoroutine(StartAttackCooldown());
        }
    }

    private IEnumerator StartAttackCooldown()
    {
        // Wait for the attack cooldown duration
        yield return new WaitForSeconds(attackCooldown);

        // Reset the attack cooldown
        isAttacking = false;
    }
    private void UpdateAnimation(State newState)
    {
        // Update the Animator "state" parameter based on the current state
        anim.SetInteger("state", (int)newState);
    }



}