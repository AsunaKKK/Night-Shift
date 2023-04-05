using UnityEngine;

public class Enemy_Controller : MonoBehaviour
{
    public Waypoint[] wayPoints;
    public float speed = 4f;
    public bool isCircular;
    public bool inReverse = true;
    public bool canWalk = true;
    public float runRange = 2f;
    public string playerTag = "Player";

    private Waypoint currentWaypoint;
    private int currentIndex = 0;
    private bool isWaiting = false;
    private float originalSpeed;

    private bool isChasingPlayer = false;
    private Vector3 playerPosition;

    void Start()
    {
        if (wayPoints.Length > 0)
        {
            currentWaypoint = wayPoints[0];
        }
        originalSpeed = speed;
    }

    void Update()
    {
        if (canWalk && !isChasingPlayer && currentWaypoint != null && !isWaiting)
        {
            // Check if the player is within range
            GameObject player = GameObject.FindGameObjectWithTag(playerTag);
            if (player != null && Vector3.Distance(transform.position, player.transform.position) < runRange)
            {
                // Call the Run function if the player is within range
                Run(player.transform.position);
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
    }

    void Pause()
    {
        isWaiting = !isWaiting;
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = currentWaypoint.transform.position;

        // Only move along the x-axis (left or right)
        targetPosition.y = currentPosition.y;
        targetPosition.z = currentPosition.z;

        if (Vector3.Distance(currentPosition, targetPosition) > 0.1f)
        {
            Vector3 directionOfTravel = (targetPosition - currentPosition).normalized;

            transform.Translate(
                directionOfTravel * speed * Time.deltaTime,
                Space.World
            );
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
        speed = 6.5f;

        // Set the current waypoint to the player's position
        currentWaypoint.transform.position = playerPosition;

        // Start chasing the player
        isChasingPlayer = true;
        this.playerPosition = playerPosition;
    }

    private void MoveTowardsPlayer()
    {
        if (Vector3.Distance(transform.position, playerPosition) > 0.1f)
        {
            Vector3 directionOfTravel = (playerPosition - transform.position).normalized;
            transform.Translate(
           directionOfTravel * speed * Time.deltaTime,
           Space.World
       );
        }
        else
        {
            // Stop chasing the player when we reach their position
            isChasingPlayer = false;
            speed = originalSpeed;
            currentWaypoint = wayPoints[currentIndex];
        }
    }
}