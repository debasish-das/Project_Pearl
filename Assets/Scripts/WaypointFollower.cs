using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField]
    private GameObject[] waypoints;
    [SerializeField]
    private float speed = 50f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < 0.1f)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex == waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }

        var distance = Time.deltaTime * speed;
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, distance);
    }
}
