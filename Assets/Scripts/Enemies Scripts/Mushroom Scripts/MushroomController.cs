using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
    [SerializeField] private float shootingRange;

    private Transform player;

    [SerializeField] internal Transform mushFirePoint;
    [SerializeField] private GameObject mushBulletPrefab;

    [SerializeField] private float fireRate = 3f;
    private float nextFireTime;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);
        if (distanceFromPlayer <= shootingRange && nextFireTime < Time.time)
        {
            Instantiate(mushBulletPrefab, mushFirePoint.position, Quaternion.identity); //Создание префаба пули в точке firePoint.position с углом firePoint.rotation
            nextFireTime = Time.time + fireRate;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, shootingRange);
    }
}
