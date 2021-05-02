using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroCollision : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("DeathWire"))
        {
            astroScr.astroDmg.TakeDamage(1);
        }
    }
}
