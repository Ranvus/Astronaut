using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroCollision : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathWire"))
        {
            astroScr.astroDmg.TakeDamage(1);
            astroScr.rb.AddForce(-astroScr.rb.velocity.normalized * astroScr.knockbackForce, ForceMode2D.Impulse);
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(KnockBack());
        }
    }*/

    IEnumerator KnockBack()
    {
        astroScr.canShoot = false;
        yield return new WaitForSeconds(.5f);
        astroScr.canShoot = true;
        astroScr.rb.AddForce(-transform.position * astroScr.knockbackForce, ForceMode2D.Impulse);
    }

}
