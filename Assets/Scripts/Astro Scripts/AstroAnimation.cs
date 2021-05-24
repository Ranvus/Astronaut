using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAnimation : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private Animator anim;

    [SerializeField] private Transform hands;

    internal bool bodyUp;
    internal bool bodyDown;
    internal bool isDead = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        AnimUpdate();

        // Решает куда будет смотреть тело вниз, вверх или вбок
        if (astroScr.astroHandsChScr.angle > astroScr.downLookAngle || astroScr.astroHandsChScr.angle < -astroScr.downLookAngle)
        {
            bodyDown = true;
        }
        else if (astroScr.astroHandsChScr.angle < astroScr.upLookAngle && astroScr.astroHandsChScr.angle > -astroScr.upLookAngle)
        {
            bodyUp = true;
        }
        else
        {
            bodyUp = false;
            bodyDown = false;
        }

        if (HPVisual.hpSystemStatic.IsDead())
        {
            isDead = true;
        }

        //StartCoroutine(Death());
    }

    private void AnimUpdate()
    {
        anim.SetBool("BodyDown", bodyDown);
        anim.SetBool("BodyUp", bodyUp);
        anim.SetBool("IsAttract", astroScr.astroAttractScr.isAttract);
        anim.SetBool("IsMove", astroScr.isMove);
        anim.SetBool("IsDead", isDead);
        anim.SetInteger("HP", astroScr.hp);
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1f);
        isDead = false;
    }
}
