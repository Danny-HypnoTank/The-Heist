using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform firePoint;
    [SerializeField]
    private float fireRate;
    [SerializeField]
    private float shotDelay;

    private void Start()
    {
        InvokeRepeating("Fire", shotDelay, fireRate);
    }

    private void Fire()
    {
        Instantiate(bullet, firePoint.position, firePoint.rotation);
    }
}
