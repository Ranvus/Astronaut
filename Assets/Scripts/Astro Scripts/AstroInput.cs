using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroInput : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Input variables")]
    internal Vector2 dir;
    internal Vector2 mousePos;
    internal bool rotateBtnActive = true;

    [SerializeField] private AudioSource shootSound;

    private void Start()
    {
        print("Astro Input");
    }

    private void Update()
    {
        dir.x = Input.GetAxis("Horizontal");
        dir.y = Input.GetAxis("Vertical");

        if (rotateBtnActive)
        {
            astroScr.astroManScr.Rotate(transform, dir.x * -astroScr.rotationSpeed);
        }

        if (Input.GetButtonDown("Fire1") && (astroScr.canShoot == true))
        {
            astroScr.astroShootScr.Shoot();
            astroScr.astroManScr.Recoil(-40f);
            astroScr.isMove = true;
            shootSound.Play();
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            StartCoroutine(DelayAnimMove());
        }
    }

    IEnumerator DelayAnimMove()
    {
        yield return new WaitForSeconds(2f);

        astroScr.isMove = false;
    }
}
