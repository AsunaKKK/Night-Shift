using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy_Controller : MonoBehaviour
{
    public List<Vector2> waypoints;
    public float speed;
    public float rotationSpeed;
    public float rotationThreshold = 1f; // Angle threshold for smooth rotation

    private int currentWaypointIndex = 0;
    private float distanceToNextWaypoint;
    private Quaternion targetRotation;

    private void Start()
    {
        distanceToNextWaypoint = Vector2.Distance(transform.position, waypoints[currentWaypointIndex]);
        UpdateRotation();
    }

    private void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        distanceToNextWaypoint -= speed * Time.deltaTime;
        if (distanceToNextWaypoint < 0f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            distanceToNextWaypoint = Vector2.Distance(transform.position, waypoints[currentWaypointIndex]);
            UpdateRotation();
        }

        // Smoothly rotate towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void UpdateRotation()
    {
        Vector2 directionToWaypoint = waypoints[currentWaypointIndex] - (Vector2)transform.position;
        float targetAngle = Mathf.Atan2(directionToWaypoint.y, directionToWaypoint.x) * Mathf.Rad2Deg;
        targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
    }
}