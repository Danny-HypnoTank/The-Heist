using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


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
    public float speed = 0.3f;
    #endregion

    #region Cop Player Variables
    public bool playerSpotted = false;

    [SerializeField]
    private Transform player;
    private NavMeshAgent agent;
    #endregion

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.enabled = false;
    }

    private void FixedUpdate()
    {
        EnemyMovement();
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
                EnemyRotation();
            }
            else if (playerSpotted == true)
            {
                agent.enabled = true;
                ChaseMovement();
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

    private void ChaseMovement()
    {
        agent.SetDestination(player.position);
    }
    #endregion
}