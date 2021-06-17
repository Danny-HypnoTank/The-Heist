using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmouredCar : MonoBehaviour
{
    [SerializeField]
    private int Health;
    [SerializeField]
    private GameObject moneyOBJ;
    private int moneySpawnNum = 1;
    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "PBullet")
        {
            Health--;
            if (Health <= 0)
            {
                for (int i = 0; i < moneySpawnNum; i++)
                {
                    Vector3 spawnPosition = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(moneyOBJ, spawnPosition, spawnRotation);
                    if (explosion != null)
                    {
                        Instantiate(explosion, transform.position, transform.rotation);
                    }
                }
                Destroy(this.gameObject);
            }
        }
    }
}
