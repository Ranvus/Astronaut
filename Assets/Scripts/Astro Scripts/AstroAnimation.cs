using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAnimation : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private Animator anim;

    [SerializeField] private Transform hands;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //anim.SetFloat("HandsAngle", hands.eulerAngles.z);
        if (astroScr.astroHandsChScr.angle > 150f || astroScr.astroHandsChScr.angle < -150f)
        {
            anim.SetBool("BodyDown", true);
        }
        else if (astroScr.astroHandsChScr.angle < 20f && astroScr.astroHandsChScr.angle > -20f)
        {
            anim.SetBool("BodyUp", true);
        }
        else
        {
            anim.SetBool("BodyDown", false);
            anim.SetBool("BodyUp", false);
        }
    }
}
