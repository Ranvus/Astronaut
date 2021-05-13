using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBullet : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float turretBulletSpeed;

    [SerializeField] private int turretDmg = 1;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, turretBulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 10);


        Vector2 bulletDir = player.position - transform.position;
        float turretGunAngle = Mathf.Atan2(bulletDir.y, bulletDir.x) * Mathf.Rad2Deg - 180f;
        Quaternion bulletRot = Quaternion.AngleAxis(turretGunAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, bulletRot, 5f * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Character"))
        {
            Destroy(gameObject);
        }

        AstroTakeDamage astro = collision.GetComponent<AstroTakeDamage>();

        print(astro);

        if (astro != null)
        {
            astro.TakeDamage(turretDmg);
        }
    }
}
