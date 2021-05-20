using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveCop : MonoBehaviour
{
    #region Game Progress Variables
    [SerializeField]
    private HeistTracker heistTracker;
    #endregion

    #region Cop Waypoint Movement Variables
    [SerializeField]
    private Transform[] waypoints;
    int cur = 0;
    [SerializeField]
    private Rigidbody2D enemyRB;
    public float speed = 4;
    #endregion

    #region Cop Player Variables
    [SerializeField]
    private GameObject player;
    public bool playerSpotted = false;
    #endregion

    private void FixedUpdate()
    {
        EnemyMovement();
        EnemyRotation();
    }

    #region Enemy Functions
    private void EnemyMovement()
    {
        if (heistTracker.EnabledCops == true)
        {
            if (playerSpotted == false)
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
            else if (playerSpotted == true)
            {
                Vector2 playerP = Vector2.MoveTowards(transform.position, player.transform.position, speed);
                enemyRB.MovePosition(playerP);
            }
        }
    }

    private void EnemyRotation()
    {
        // Animation
        Vector2 dir = waypoints[cur].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    #endregion
}