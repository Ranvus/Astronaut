using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroHandsChange : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private Animator anim;

    [SerializeField] AstroHandsRotate astroHands;
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;
    internal SpriteRenderer handsSr;

    internal float angle;

    void Start()
    {
        anim = GetComponent<Animator>();
        handsSr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {

        // flatten z axis
        astroHands.aimDir.z = 0;

        Vector3 neutralDir = player.up; //Присваивает neutralDir значение вектора поворота оси Y(зеленая координата). В отличии от Vector2.up учитывает вращение
        angle = Vector3.SignedAngle(neutralDir, astroHands.aimDir, Vector3.forward);

        if (angle > astroScr.downLookAngle || angle < -astroScr.downLookAngle)
        {
            anim.SetBool("HandsDown", true);
            astroScr.secondHand.SetActive(false);
            //transform.localPosition = new Vector3(-0.045f, 0.139f, 0f);
            firePoint.localPosition = new Vector3(-0.359f, 0.041f, 0f);
        }
        else if (angle < astroScr.upLookAngle && angle > -astroScr.upLookAngle)
        {
            anim.SetBool("HandsUp", true);
            astroScr.secondHand.SetActive(false);
            //transform.localPosition = new Vector3(-0.045f, 0.3f, 0f);
            firePoint.localPosition = new Vector3(-0.522f, -0.043f, 0f);
        }
        else
        {
            anim.SetBool("HandsDown", false);
            anim.SetBool("HandsUp", false);
            astroScr.secondHand.SetActive(true);
            //transform.localPosition = new Vector3(0.073f, 0.183f, 0f);
            firePoint.localPosition = new Vector3(-0.4990001f, 0.058f, 0f);
        }
    }
}
