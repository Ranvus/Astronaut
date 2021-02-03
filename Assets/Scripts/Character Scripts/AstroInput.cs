using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroInput : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Input variables")]
    internal Vector2 dir;
    internal Vector2 mousePos;

    private void Start()
    {
        print("Astro Input");
    }

    private void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        //print("a" + astroScr.canShoot);

        if (Input.GetButtonDown("Fire1") && (astroScr.canShoot == true))
        {
            astroScr.astroShootScr.Shoot();
            astroScr.astroManScr.ThrustForward(-40f);
        }
    }
}
