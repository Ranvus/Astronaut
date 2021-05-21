using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroTakeDamage : MonoBehaviour
{
    [SerializeField] internal AstroScript astroScr;

    internal void TakeDamage(int damage)
    {
        astroScr.hp -= damage;

        if (astroScr.hp <= 0)
        {
            Death();
            //astroScr.astroAnimScr.isDead = true;
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
