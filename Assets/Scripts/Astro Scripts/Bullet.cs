using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] internal int astroDmg = 1;

    private void Update()
    {
        Destroy(gameObject, 4f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Rocket"))
        {
            Destroy(gameObject);
        }
    }
}
