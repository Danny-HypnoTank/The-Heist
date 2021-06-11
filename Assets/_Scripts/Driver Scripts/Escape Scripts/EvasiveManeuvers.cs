using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuvers : MonoBehaviour
{
    [SerializeField]
    private float smoothing;
    [SerializeField]
    private float dodge;

    [SerializeField]
    private Vector2 startWait;
    [SerializeField]
    private Vector2 maneuverTime;
    [SerializeField]
    private Vector2 maneuverWait;
    public Boundary boundary;

    [SerializeField]
    private Mover currentSpeed;
    private float targetManeuver;
    [SerializeField]
    private Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(Evade());        
    }

    IEnumerator Evade()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }

    private void FixedUpdate()
    {
        float newManeuver = Mathf.MoveTowards(rb.velocity.x, targetManeuver, Time.deltaTime * smoothing);

        rb.velocity = new Vector3(newManeuver, currentSpeed.speed, 0.0f);

        rb.position = new Vector3
        (
            Mathf.Clamp (rb.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(rb.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }
}
