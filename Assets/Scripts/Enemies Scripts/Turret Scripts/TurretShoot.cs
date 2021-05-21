using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretShoot : MonoBehaviour
{
    [SerializeField] TurretScript turretScr;

    private Animator anim;
    private SpriteRenderer sprite;

    private float nextFireTime;
    private bool playerIn;

    [SerializeField] internal Transform turretFirePoint;
    [SerializeField] private GameObject turretBulletPrefab;
    [SerializeField] private Sprite finalFrame;

    private void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(turretScr.player.position, transform.position);
        if (distanceFromPlayer <= turretScr.attackRange && nextFireTime < Time.time && sprite.sprite == finalFrame)
        {
            Instantiate(turretBulletPrefab, turretFirePoint.position, turretScr.turretGunTrack.turretGunRot); //Создание префаба пули в точке firePoint.position с углом firePoint.rotation
            nextFireTime = Time.time + turretScr.fireRate;
        }

        if (distanceFromPlayer <= turretScr.attackRange)
        {
            playerIn = true;
        }
        else if (distanceFromPlayer >= turretScr.attackRange)
        {
            playerIn = false;
        }

        anim.SetBool("PlayerIn", playerIn);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, turretScr.attackRange);
    }
}
