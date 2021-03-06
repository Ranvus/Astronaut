﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroArrow : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;


    [Header("Arrow variables")]
    [SerializeField] private Transform player;

    void Start()
    {
        print("Astro Arrow");
    }

    void Update()
    {
        Vector3 dashDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position).normalized; //Нормализированное значение направления мыши с учетом позиции пресонажа
        dashDir.z = 0; //Сглаживание оси Z

        Vector3 neutralDir = player.up; //Присваивает neutralDir значение вектора поворота оси Y(зеленая координата). В отличии от Vector2.up учитывает вращение
        float angle = Vector3.SignedAngle(neutralDir, dashDir, Vector3.forward); //
        angle = Mathf.Clamp(angle, -astroScr.clampAngle, astroScr.clampAngle); //Ограничивает вращение стрелки 

        // rotate neutral dir by the clamped angle
        dashDir = Quaternion.AngleAxis(angle, Vector3.forward) * neutralDir;

        // set the rotation so that local up points in dir direction 
        // and local forward in global forward
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dashDir);

        // Отталкивание игрока от стены 
        if (Input.GetButtonDown("Fire1"))
        {
            //Булевые
            astroScr.mouseRotationActive = true;
            astroScr.astroInputScr.rotateBtnActive = true;
            astroScr.astroAttractScr.isAttract = false;
            astroScr.arrow.SetActive(false);
            astroScr.hand.SetActive(true);
            astroScr.secondHand.SetActive(true);
            MonoBehaviour camMono = Camera.main.GetComponent<MonoBehaviour>(); //Считывание MonoBehaviour камеры для последующего запуска там корутина
            camMono.StartCoroutine(ShootStart()); //Запуск корутина на камере

            //Физика
            astroScr.rb.drag = 0f;
            astroScr.rb.velocity = Vector2.zero;
            astroScr.rb.AddForce(dashDir * 15f, ForceMode2D.Impulse);
            //astroScr.hand.transform.localPosition = new Vector3(0.073f, 0.183f, 0f);
            //astroScr.astroShootScr.firePoint.localPosition = new Vector3(-0.5f, 0.058f, 0f);
        }

    }

    public IEnumerator ShootStart()
    {
        yield return new WaitForSeconds(.1f);

        astroScr.canShoot = true;
    }

}
