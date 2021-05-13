using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{


    [SerializeField] internal int astroDmg = 1;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle") || collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        /*TentacleController tentacle = collision.GetComponent<TentacleController>();

        if (tentacle != null)
        {
            print(tentacle.curHp);
            tentacle.TakeDamage(tentacle.curHp, astroDmg);
        }*/
    }
}
