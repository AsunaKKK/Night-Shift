using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy_Controller : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 5f;

    private int currentWaypointIndex = 0;

    private void Start()
    {
        if (waypoints.Length > 0)
        {
            // Set the initial position to the first waypoint
            transform.position = waypoints[currentWaypointIndex].position;
        }
    }

    private void Update()
    {
        if (waypoints.Length > 0)
        {
            // Move towards the current waypoint
            Transform currentWaypoint = waypoints[currentWaypointIndex];
            Vector3 direction = (currentWaypoint.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);

            // Check if the enemy is close enough to the current waypoint
            if (Vector3.Distance(transform.position, currentWaypoint.position) < 0.1f)
            {
                // Move to the next waypoint
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
        }
    }
}