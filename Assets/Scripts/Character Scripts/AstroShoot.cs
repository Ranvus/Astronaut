using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroShoot : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Shoot variables")]
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    private void Start()
    {
        print("Astro Shoot");
    }

    internal void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * astroScr.bulletForce, ForceMode2D.Impulse);
    }
}
