using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomBullet : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float mushBulletSpeed;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, mushBulletSpeed * Time.deltaTime);
        Destroy(this.gameObject, 10);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Character"))
        {
            Destroy(gameObject);
        }
    }
}
