using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroTakeDamage : MonoBehaviour
{
    [SerializeField] internal AstroScript astroScr;

    void Update()
    {
        
    }

    internal void TakeDamage(int damage)
    {
        astroScr.hp -= damage;

        if (astroScr.hp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + .5f);
    }
}
