using UnityEngine;
using System.Collections;

public class Enemy_Controller : MonoBehaviour
{
    //Move
    public Waypoint[] wayPoints;
    public float speed = 5f;
    public bool isCircular;
    public bool inReverse = true;
    public bool canWalk = true;
    public float runRange = 2f;
    private Waypoint currentWaypoint;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float originalSpeed;
    private Vector2 playerPosition;

    private GameObject currentTeleporter;


    // Attack
    public static bool isChasingPlayer = false;

    public static bool isAttacking = false;
    private bool hasHitPlayer = true;
    //public float attackRange = 0f;
    public int attackDamage = 10;
    public float attackCooldown = 2f;

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
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


        Move();

    }

    private void Pause()
    {
        isWaiting = !isWaiting;
        state = State.Idle;
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = currentWaypoint.transform.position;

        targetPosition.y = currentPosition.y;
        targetPosition.z = currentPosition.z;

        if (Vector3.Distance(currentPosition, targetPosition) > 0.1f)
        {
            Vector3 directionOfTravel = (targetPosition - currentPosition).normalized;
            transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
            state = State.Walk;

            FlipEnemy(directionOfTravel.x);
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
        }


    }

    private void FlipEnemy(float directionX)
    {
        if (directionX < 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (directionX > 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void NextWaypoint()
    {
        if (!isChasingPlayer)
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
    }

    private void Run(Vector3 playerPosition)
    {
        runRange = float.PositiveInfinity;
        speed = 8f;
        isChasingPlayer = true;
        this.playerPosition = playerPosition;
        state = State.Run;
        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
        }
    }

    private void MoveTowardsPlayer()
    {
        float playerX = playerPosition.x;
        float enemyX = transform.position.x;

        if (Mathf.Abs(playerX - enemyX) > 0.1f)
        {
            float directionX = Mathf.Sign(playerX - enemyX);
            Vector3 directionOfTravel = new Vector3(directionX, 0, 0);

            transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
            FlipEnemy(directionX);
        }
        else
        {
            isChasingPlayer = false;
            speed = originalSpeed;
            currentWaypoint = wayPoints[currentIndex];
        }

        if (isAttacking)
        {
            AttackPlayer();
        }
    }
    private void Move()
    {
        UpdateAnimation(state);

        if (canWalk && !isChasingPlayer && currentWaypoint != null && !isWaiting)
        {
            // Find the nearest gameobject with the tag "EnemyTele"
            GameObject enemyTele = GameObject.FindGameObjectWithTag("EnemyTele");

            if (enemyTele != null)
            {
                float distanceToTeleporter = Vector3.Distance(transform.position, enemyTele.transform.position);

                if (distanceToTeleporter < runRange)
                {
                    Run(enemyTele.transform.position);
                    return;
                }
            }

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null && Vector3.Distance(transform.position, player.transform.position) < runRange)
            {
                Run(player.transform.position);
            }
            else
            {
                MoveTowardsWaypoint();
            }
        }
        else if (isChasingPlayer)
        {
            float playerX = playerPosition.x;
            float enemyX = transform.position.x;

            if (Mathf.Abs(playerX - enemyX) > 0.1f)
            {
                float directionX = Mathf.Sign(playerX - enemyX);
                Vector3 directionOfTravel = new Vector3(directionX, 0, 0);

                transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
                FlipEnemy(directionX);
            }
            else
            {
                isChasingPlayer = false;
                speed = originalSpeed;
                currentWaypoint = wayPoints[currentIndex];
            }

            if (isAttacking)
            {
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        if (hasHitPlayer)
        {
            state = State.Attack;
            // Check if the player is within attack range
            //if (Vector3.Distance(transform.position, playerPosition) < attackRange)

            // Access the player GameObject
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Access the player's script
                PlayerController playerController = player.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    // Deal damage to the player
                    playerController.TakeDamage(attackDamage);
                    hasHitPlayer = false;
                    Debug.Log(attackDamage);
                }
            }

            StartCoroutine(StartAttackCooldown());
        }


    }

    private IEnumerator StartAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        isAttacking = false;
        hasHitPlayer = true;
        Debug.Log(isAttacking + "AttackStop");
    }

    private void UpdateAnimation(State newState)
    {
        anim.SetInteger("state", (int)newState);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyTele"))
        {
            currentTeleporter = collision.gameObject;
        }
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
        }


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTeleporter)
        {
            currentTeleporter = null;
            collision.tag = "Teleporter";
            isAttacking = false;
        }
    }

}