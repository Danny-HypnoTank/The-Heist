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

    [SerializeField]
    private Animator muzzleAnimator;

    private void Start()
    {
        InvokeRepeating("Fire", shotDelay, fireRate);
    }

    private void Fire()
    {
        muzzleAnimator.SetBool("Shooting", true);
        Instantiate(bullet, firePoint.position, firePoint.rotation);
        StartCoroutine(MuzzleStop());
    }

    IEnumerator MuzzleStop()
    {
        yield return new WaitForSeconds(.09f);
        muzzleAnimator.SetBool("Shooting", false);
    }

}
