using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int CurrentIndex=0;

    [SerializeField] private float speed = 3f;

    private void Update()
    {
        if (Vector2.Distance(waypoints[CurrentIndex].transform.position, transform.position) < 0.1f)
        {
            CurrentIndex++;
            CurrentIndex %= waypoints.Length;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[CurrentIndex].transform.position,
            Time.deltaTime * speed);
    }
}
