using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex=0;

    [SerializeField] private float speed=2f;
    private void Update()
    {
            if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position,transform.position) < 0.01f)//2nd param is for the obj the script is for
            //can't use == 0f for floats,because of precision loss...this condition is same as   ->    == 0f
            {
                currentWaypointIndex++;
                if(currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex=0;
                }
            }
            transform.position=Vector2.MoveTowards(transform.position,waypoints[currentWaypointIndex].transform.position,Time.deltaTime * speed);
    }
}