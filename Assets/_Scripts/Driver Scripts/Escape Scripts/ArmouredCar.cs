using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredCar : MonoBehaviour
{
    [SerializeField]
    private int Health;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PBullet")
        {
            Health--;
            if (Health <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
