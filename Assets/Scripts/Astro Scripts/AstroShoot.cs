using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroShoot : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Shoot variables")]
    [SerializeField] internal Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [Header("Bullet сomponents")]
    internal Rigidbody2D bulletRb;

    private void Start()
    {
        print("Astro Shoot");
    }

    internal void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); //Создание префаба пули в точке firePoint.position с углом firePoint.rotation
        bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * astroScr.bulletForce, ForceMode2D.Impulse); //Задание силы пуле в направлении firePoint.up
    }
}
