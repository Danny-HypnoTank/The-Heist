using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPacManTest : MonoBehaviour
{
    public float speed = 0.4f;
    Vector2 _dest = Vector2.zero;
    Vector2 _dir = Vector2.zero;
    Vector2 _nextDir = Vector2.zero;

    [SerializeField]
    private bool boosting = false;
    [SerializeField]
    private HeistTracker heistTracker;

    void Start()
    {
        _dest = transform.position;
    }

    void FixedUpdate()
    {
        if (heistTracker.droppingOff == false)
        {
            ReadInputAndMove();
            UpdateOrientation();
        }
        else
        {

        }
    }

    #region Player Movement Functions
    void ReadInputAndMove()
    {
        // move closer to destination
        Vector2 p = Vector2.MoveTowards(transform.position, _dest, speed);
        GetComponent<Rigidbody2D>().MovePosition(p);

        // get the next direction from keyboard
        if (Input.GetAxis("Horizontal") > 0) _nextDir = Vector2.right;
        if (Input.GetAxis("Horizontal") < 0) _nextDir = -Vector2.right;
        if (Input.GetAxis("Vertical") > 0) _nextDir = Vector2.up;
        if (Input.GetAxis("Vertical") < 0) _nextDir = -Vector2.up;

        // if pacman is in the center of a tile
        if (Vector2.Distance(_dest, transform.position) < 0.00001f)
        {
            if (Valid(_nextDir))
            {
                _dest = (Vector2)transform.position + _nextDir;
                _dir = _nextDir;
            }
            else   // if next direction is not valid
            {
                if (Valid(_dir))  // and the prev. direction is valid
                    _dest = (Vector2)transform.position + _dir;   // continue on that direction

                // otherwise, do nothing
            }
        }
    }

    private void UpdateOrientation()
    {
        if (_dir == -Vector2.right)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_dir == Vector2.right)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (_dir == Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (_dir == -Vector2.up)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.localRotation = Quaternion.Euler(0, 0, 270);
        }
    }

    bool Valid(Vector2 direction)
    {
        // cast line from 'next to pacman' to pacman
        // not from directly the center of next tile but just a little further from center of next tile
        Vector2 pos = transform.position;
        direction += new Vector2(direction.x * 0.45f, direction.y * 0.45f);
        RaycastHit2D hit = Physics2D.Linecast(pos + direction, pos);
        return hit.collider.tag != "Roads"; // hit.collider == GetComponent<Collider2D>();
    }

    public void ResetDestination()
    {
        _dest = new Vector2(15f, 11f);
    }

    public Vector2 getDir()
    {
        return _dir;
    }
    #endregion

    #region Player Collision Functions
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DropOffPoint")
        {
            heistTracker.droppingOff = true;
            transform.position = collision.gameObject.transform.position;
        }
        if (collision.gameObject.tag == "PickUpPoint")
        {
            heistTracker.pickedUpHeisters = true;
            heistTracker.pickupRequired = false;
        }
        if (collision.gameObject.tag == "Exit")
        {
            heistTracker.heistersEscape = true;
            heistTracker.HeistConditions();
        }
        if (collision.gameObject.tag == "Detector")
        {
            collision.gameObject.GetComponentInParent<ActiveCop>().playerSpotted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Enemy")
        {
            if (boosting == true)
            {

            }
            else
            {
                heistTracker.heistersCaught = true;
                heistTracker.HeistConditions();
            }
        }

        if (collider.gameObject.tag == "Wall")
        {
            if (boosting == true)
            {
                collider.gameObject.SetActive(false);
            }
        }
    }
    #endregion

    #region Player Ability Functions
    public void BoostButton()
    {
        if (boosting == false)
        {
            boosting = true;
            speed = speed * 2;
            StartCoroutine(BoostTimer());
        }
    }

    IEnumerator BoostTimer()
    {
        yield return new WaitForSeconds(5);
        speed = speed / 2;
        boosting = false;
    }
    #endregion
}