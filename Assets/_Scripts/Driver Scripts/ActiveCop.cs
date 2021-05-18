using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCop : MonoBehaviour
{
    [SerializeField]
    private Transform[] waypoints;
    int cur = 0;
    [SerializeField]
    private Rigidbody2D enemyRB;
    public float speed = 4;
    [SerializeField]
    private HeistTracker heistTracker;


    private void FixedUpdate()
    {
        if (heistTracker.EnabledCops == true)
        {
            if (transform.position != waypoints[cur].position)
            {
                Vector2 p = Vector2.MoveTowards(transform.position, waypoints[cur].position, speed);
                enemyRB.MovePosition(p);
            }
            else
            {
                cur = (cur + 1) % waypoints.Length;
            }
        }
    }
}
