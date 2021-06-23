using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private int boostCount;
    private bool boosting = false;
    private bool slowTime = false;
    private int slowTimeCount = 1;
    [SerializeField]
    private Image boostButton;
    [SerializeField]
    private Image slowButton;

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
    [SerializeField]
    private ShakeController shakeController;
    [SerializeField]
    private BGScroller bgscroll;

    [SerializeField]
    private Slider healthSlider;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private Animator muzzleAnimator;

    private void Start()
    {
        healthSlider.value = playerHealth;
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
        healthSlider.value = playerHealth;
    }

    private void Update() //Player Shooting
    {
        if (gameController.Gameover == false && gameController.Victory == false)
        {
            if (Input.GetButton("Fire1") && Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                muzzleAnimator.SetBool("Shooting", true);
                Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
                StartCoroutine(MuzzleStop());
            }

            if (playerHealth <= 0)
            {
                if (explosion != null)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }
                gameController.Gameover = true;
            }
        }
    }

    IEnumerator MuzzleStop()
    {
        yield return new WaitForSeconds(.09f);
        muzzleAnimator.SetBool("Shooting", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameController.Gameover == false && gameController.Victory == false)
        {
            if (boosting == true)
            {
                if (other.CompareTag("Enemy"))
                {
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("AEnemy"))
                {
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Obstacle"))
                {
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Bullet"))
                {
                    if (explosion != null)
                    {
                        Instantiate(explosion, other.transform.position, other.transform.rotation);
                    }
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Money"))
                {
                    gameController.Score = gameController.Score + 10;
                    Destroy(other.gameObject);
                }
            }
            else
            {
                if (other.CompareTag("Enemy"))
                {
                    playerHealth--;
                    //Play anim
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("AEnemy"))
                {
                    playerHealth--;
                    //Play anim
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Obstacle"))
                {

                    playerHealth--;
                    //Play anim
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    //Slow time
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Bullet"))
                {
                    if (explosion != null)
                    {
                        Instantiate(explosion, other.transform.position, other.transform.rotation);
                    }
                    playerHealth--;
                    //Play anim
                    //shake camera
                    StartCoroutine(shakeController.Shake(.15f, .4f));
                    Destroy(other.gameObject);
                }
                else if (other.CompareTag("Money"))
                {
                    gameController.Score = gameController.Score + 10;
                    Destroy(other.gameObject);
                }
            }
        }     
    }

    public void BoostButton()
    {
        //Change player speed
        //If charges 
        if (boostCount > 0 && boosting == false && slowTime == false)
        {
            boosting = true;
            StartCoroutine(IncreaseSpeed());
        }
    }

    IEnumerator IncreaseSpeed()
    {
        boosting = true;
        boostCount--;
        speed = speed * 2;
        bgscroll.ScrollSpeed = bgscroll.ScrollSpeed * 2;
        yield return new WaitForSeconds(3);
        speed = speed / 2;
        bgscroll.ScrollSpeed = bgscroll.ScrollSpeed / 2;
        boosting = false;
    }

    public void SlowTimeButton()
    {
        if (slowTimeCount > 0)
        {
            //Slow Time
            //only be able to do once
            slowTime = true;
            StartCoroutine(SlowTime());
        }

    }

    IEnumerator SlowTime()
    {
        slowTime = true;
        slowTimeCount--;
        Time.timeScale = 0.5f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        yield return new WaitForSeconds(2);
        Time.timeScale = 1.0f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        slowTime = false;
    }
}
