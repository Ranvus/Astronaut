using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroTakeDamage : MonoBehaviour
{
    [SerializeField] internal AstroScript astroScr;

    internal void TakeDamage(int damage)
    {
        HPVisual.hpSystemStatic.Damage(damage);
        if (HPVisual.hpSystemStatic.IsDead())
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + 1f);
        astroScr.hand.SetActive(false);
        astroScr.secondHand.SetActive(false);
        astroScr.canShoot = false;
    }
}
