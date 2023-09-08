using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemy_Controller : MonoBehaviour
{
    //Move
    public Waypoint[] wayPoints;
    public float speed = 6f;
    public bool isCircular;
    public bool inReverse = true;
    public bool canWalk = true;
    public float runRange = 15f;
    public float lockDoor = 15f;
    public static bool stopDoThat = false;
    private Waypoint currentWaypoint;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float originalSpeed;
    private Vector2 playerPosition;
    public static bool chackQuest12 = false;

    public List<GameObject> enemyTeleporters = new List<GameObject>();

    private GameObject currentTeleporter;
    private Vector3 initialWaypointPosition;
   

    // Attack
    public static bool isChasingPlayer = false;

    public static bool isAttacking = false;
    private bool hasHitPlayer = true;
    public int attackDamage = 10;
    public float attackCooldown = 2f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator anim;

    private enum State { Idle, Walk, Run, Attack }
    private State state = State.Idle;

    /// <summary>
    /// /sound
    /// </summary>
    public AudioSource cashSound;
    public AudioSource detech;
    public AudioSource walk;
    public AudioSource run;
    public AudioSource attack;
    [Header("Sound Range")]
    [Tooltip("The range of sound detection for the enemy.")]
    [Range(0f, 100f)] 
    public float soundAround = 30f;

    private void Start()
    {
        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
        originalSpeed = speed;
        anim = GetComponent<Animator>();
        cashSound.enabled = false;
        detech.enabled = false;
        initialWaypointPosition = wayPoints[0].transform.position;
    }

    private void OnEnable()
    {
        cashSound.enabled = false;
        detech.enabled = false;
        walk.enabled = false;
        run.enabled = false;
        attack.enabled = false;
    }

    private void Update()
    {
        UpdateAnimation(state);
        if (currentTeleporter != null)
        {
            transform.position = currentTeleporter.GetComponent<Telepor>().GetDestination().position;
        }

        if (!isChasingPlayer)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                float maxSoundDistance = soundAround * 3.0f; 

                if (distanceToPlayer <= soundAround)
                {
                   
                    float volume = 1f - (distanceToPlayer / maxSoundDistance);
                    walk.volume = volume;
                    walk.enabled = true;
                }
                else
                {
                    walk.enabled = false;
                }
            }
            else
            {
               
                walk.enabled = false;
            }
            if (player != null && Vector3.Distance(transform.position, player.transform.position) < runRange)
            {
                StartChasing(player.transform.position);
                cashSound.enabled = true;
                detech.enabled = true;

            }
            else
            {
                MoveTowardsWaypoint();
               
            }
            
            

        }

        if (isChasingPlayer)
        {
            walk.enabled = false;

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
                float maxSoundDistance = soundAround * 3.0f;

                if (distanceToPlayer <= soundAround)
                {

                    float volume = 1f - (distanceToPlayer / maxSoundDistance);
                    run.volume = volume;
                    run.enabled = true;
                }
                else
                {
                    run.enabled = false;
                }
            }
            else
            {

                walk.enabled = false;
            }
            if (player != null && Vector3.Distance(transform.position, player.transform.position) < lockDoor)
            {
               stopDoThat = true;
            }
            else
            {
                stopDoThat = false;
            }
            if (player != null)
            {
                StartChasing(player.transform.position);
            }
            else
            {
                StopChasing();
                chackQuest12 = true;
            }

        }
        if (isAttacking)
        {
            AttackPlayer();
           attack.enabled = true;
           
        }
       

        
    }

    private void StartChasing(Vector3 playerPosition)
    {
        GameObject[] enemyTeleportersArray = GameObject.FindGameObjectsWithTag("EnemyTele");

        enemyTeleporters.Clear();
        enemyTeleporters.AddRange(enemyTeleportersArray);
        

            if (enemyTeleporters.Count > 0)
            {
                GameObject nextTeleporter = enemyTeleporters[0];
                float enemyTeleX = nextTeleporter.transform.position.x;
                float enemyX = transform.position.x;

                if (Mathf.Abs(enemyTeleX - enemyX) > 0.1f)
                {
                    float directionX = Mathf.Sign(enemyTeleX - enemyX);
                    Vector3 directionOfTravel = new Vector3(directionX, 0, 0);

                    transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
                    FlipEnemy(directionX);
                }
                if (!isAttacking)
                {
                    runRange = float.PositiveInfinity;
                    speed = 8f;
                    isChasingPlayer = true;
                    this.playerPosition = playerPosition;
                    state = State.Run;
                }
                else
                {
                    speed = 0;                   

                }
            }
            else
            {
                if (!isAttacking)
                {
                    speed = 9f;
                    isChasingPlayer = true;
                    this.playerPosition = playerPosition;
                    state = State.Run;
                }
                else
                {
                    speed = 0;                 
                }

                float playerX = playerPosition.x;
                float enemyX = transform.position.x;

                if (Mathf.Abs(playerX - enemyX) > 0.1f)
                {
                    float directionX = Mathf.Sign(playerX - enemyX);
                    Vector3 directionOfTravel = new Vector3(directionX, 0, 0);

                    transform.Translate(directionOfTravel * speed * Time.deltaTime, Space.World);
                    FlipEnemy(directionX);
                }
            }

        
    }

    public void StopChasing()
    {
        runRange = 15f;
        speed = 4.5f;       
        StartCoroutine(MoveToHiddenPosition());
        run.enabled = false;

        if (enemyTeleporters.Count > 0)
        {
            foreach (GameObject teleporter in enemyTeleporters)
            {
                teleporter.tag = "Teleporter";
            }

            enemyTeleporters.Clear();
        }
    }

    private IEnumerator MoveToHiddenPosition()
    {
        GameObject hiddenObject = GameObject.FindGameObjectWithTag("Hidden");

        if (hiddenObject != null)
        {
            state = State.Walk;
            walk.enabled = true; 
            Vector3 targetPosition = hiddenObject.transform.position;

           
            float delayDuration = 2f;
            float delayStartTime = Time.time;
            while (Time.time < delayStartTime + delayDuration)
            {
                yield return null; 
            }
            
            transform.position = targetPosition; 

            float moveDistance = 5f;
            float moveDuration = 10f;

            Vector3 leftPosition = targetPosition + Vector3.left * moveDistance;
            Vector3 rightPosition = targetPosition + Vector3.right * moveDistance;
           
            yield return MoveToPosition(leftPosition, moveDuration, speed);
            

            yield return MoveToPosition(rightPosition, moveDuration, speed);
            


            yield return MoveToPosition(leftPosition, moveDuration, speed);
            


            state = State.Idle;

            StopAllCoroutines();
            state = State.Idle;
            isChasingPlayer = false;
            currentWaypoint = wayPoints[0];
            currentIndex = 0;
            transform.position = initialWaypointPosition;
            cashSound.enabled = false;
            detech.enabled = false;
            speed = originalSpeed;
            walk.enabled = false;
        }
    }

    private IEnumerator MoveToPosition(Vector3 targetPosition, float duration, float moveSpeed)
    {
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;
        float directionX = (targetPosition.x - startingPosition.x) > 0 ? 1f : -1f; 

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime * moveSpeed;

           
            FlipEnemy(directionX);

            yield return null;
        }

        transform.position = targetPosition;
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

    private void AttackPlayer()
    {
        if (hasHitPlayer)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                PlayerController playerController = player.GetComponent<PlayerController>();

                if (playerController != null)
                {
                    playerController.TakeDamage(attackDamage);
                    hasHitPlayer = false;
                   
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
        attack.enabled = false;
        
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
          
            state = State.Attack;
            isAttacking = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyTele"))
        {
            currentTeleporter = collision.gameObject;
        }
        if (collision.CompareTag("Player"))
        {
            isAttacking = true;
            state = State.Attack;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentTeleporter)
        {
            currentTeleporter = null;
            collision.gameObject.tag = "Teleporter";
            isAttacking = false;
        }
    }
}