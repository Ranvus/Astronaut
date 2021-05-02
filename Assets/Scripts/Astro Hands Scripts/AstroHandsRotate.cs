using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroHandsRotate : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Hand variables")]
    private Vector3 arrowMousePos;
    internal Vector3 aimDir;
    internal float angle;

    private void Update()
    {
        arrowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Считывание координат мыши

        aimDir = (arrowMousePos - transform.position).normalized; //Нормализированное значение направления мыши
        angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg + 180f; //Угол на который должна повернуться рука
        transform.eulerAngles = new Vector3(0, 0, angle); //Применение высчитанного угла
    }
}
