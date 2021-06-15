using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D playerRB;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int playerHealth;

    [SerializeField]
    private float fireRate;
    private float nextFire;
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform shotSpawn;

    [SerializeField]
    private Boundary boundary;
    [SerializeField]
    private GameController gameController;

    private void Start()
    {
        
    }

    private void FixedUpdate() //Player Movement
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
        playerRB.velocity = movement * speed;

        playerRB.position = new Vector3
        (
            Mathf.Clamp(playerRB.position.x, boundary.xMin, boundary.xMax),
            Mathf.Clamp(playerRB.position.y, boundary.yMin, boundary.yMax),
            0.0f
        );
    }

    private void Update() //Player Shooting
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
        }

        if (playerHealth <= 0)
        {
            gameController.Gameover = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            playerHealth--;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Bullet"))
        {
            playerHealth--;
            Destroy(other.gameObject);
        }
    }
}
