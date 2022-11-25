using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardMovementScript : MonoBehaviour
{
    public Transform[] waypointObjects;
    public float speed = 2f;

    private Vector3[] waypoints;
    private int currentWaypoint = 0;
    private Vector3 target;

    private void Awake()
    {
        waypoints = new Vector3[waypointObjects.Length];
        for (int i = 0; i < waypointObjects.Length; i++)
        {
            waypoints[i] = waypointObjects[i].position;
        }
        target = waypoints[currentWaypoint];
    }

    private void Update()
    { 
        if (Vector3.Distance(transform.position, target) < speed * Time.deltaTime)
        {
            transform.position = target;
            currentWaypoint = (currentWaypoint + 1) % waypoints.Length;
            target = waypoints[currentWaypoint];
        }
        else
        {
            Vector3 moveDir = (target - transform.position).normalized;
            transform.position += moveDir * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }
}
