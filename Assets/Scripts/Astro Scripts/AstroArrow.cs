using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroArrow : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;


    [Header("Arrow variables")]
    private Vector3 arrowMousePos;
    [SerializeField] private Transform player;

    void Start()
    {
        print("Astro Arrow");
    }

    void Update()
    {
        //Vector2 dashDir = (arrowMousePos - player.position).normalized; //Нормализированное значение направления мыши
        //float angle = Mathf.Atan2(dashDir.y, dashDir.x) * Mathf.Rad2Deg + 90f; //Угол на который должна повернуться рука
        //transform.rotation = Quaternion.Euler(0, 0, angle); //Применение высчитанного угла

        Vector3 dashDir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - player.position).normalized; //Нормализированное значение направления мыши с учетом позиции пресонажа

        // flatten z axis
        dashDir.z = 0;

        Vector3 neutralDir = player.up; //Присваивает neutralDir значение вектора поворота оси Y(зеленая координата). В отличии от Vector2.up учитывает вращение
        float angle = Vector3.SignedAngle(neutralDir, dashDir, Vector3.forward);
        angle = Mathf.Clamp(angle, -astroScr.clampAngle, astroScr.clampAngle);

        // rotate neutral dir by the clamped angle
        dashDir = Quaternion.AngleAxis(angle, Vector3.forward) * neutralDir;

        // set the rotation so that local up points in dir direction 
        // and local forward in global forward
        transform.rotation = Quaternion.LookRotation(Vector3.forward, dashDir);

        //print(transform.localEulerAngles);

        if (Input.GetButtonDown("Fire1"))
        {
            //Булевые
            astroScr.mouseRotationActive = true;
            astroScr.astroAttractScr.arrow.SetActive(false);
            astroScr.astroInputScr.rotateBtnActive = true;
            astroScr.canShoot = true;

            //Физика
            astroScr.rb.drag = 0f;
            astroScr.rb.velocity = Vector2.zero;
            astroScr.rb.AddForce(dashDir * 15f, ForceMode2D.Impulse);
        }
    }
}
