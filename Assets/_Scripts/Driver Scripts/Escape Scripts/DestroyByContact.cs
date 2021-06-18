using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    private GameObject moneyOBJ;
    private int moneySpawnNum = 1;

    [SerializeField]
    private GameObject explosion;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            for (int i = 0; i < moneySpawnNum; i++)
            {
                Vector3 spawnPosition = new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, other.gameObject.transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(moneyOBJ, spawnPosition, spawnRotation);
            }
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if (other.CompareTag("AEnemy"))
        {
            if (explosion != null)
            {
                Instantiate(explosion, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}
