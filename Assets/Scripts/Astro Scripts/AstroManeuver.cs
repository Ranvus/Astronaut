using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroManeuver : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Maneuver variables")]
    internal Vector2 mousePos;
    internal float angle;

    [Header("Other ref")]
    [SerializeField] internal GameObject handRot;
    [SerializeField] internal GameObject firePointRot;

    internal bool right;
    
    private void Start()
    {
        print("Astro Man");
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //Считывание координат мыши
    }

    private void FixedUpdate()
    {
        astroScr.astroManScr.ClampVelocity();

        //Разворот персонажа в зависимости от расположения руки
        if (astroScr.astroHandsChScr.angle < 180f && astroScr.astroHandsChScr.angle > 0f)
        {
            transform.localScale = new Vector3(1, 1, 1);
            handRot.transform.localScale = new Vector3(1, 1, 1);
            firePointRot.transform.localRotation = Quaternion.Euler(0, 0, 90);
        }
        else if (astroScr.astroHandsChScr.angle > -180f && astroScr.astroHandsChScr.angle < 0f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            handRot.transform.localScale = new Vector3(-1, -1, 1);
            firePointRot.transform.localRotation = Quaternion.Euler(0, 180, 90);
        }
    }

    //Ограничение скорости минимум и максимумом
    internal void ClampVelocity()
    {
        float x = Mathf.Clamp(astroScr.rb.velocity.x, -astroScr.clampVelocity, astroScr.clampVelocity);
        float y = Mathf.Clamp(astroScr.rb.velocity.y, -astroScr.clampVelocity, astroScr.clampVelocity);

        astroScr.rb.velocity = new Vector2(x, y);
    }

    //Откидывание персонажа отдачей в противоположное направление от пули
    internal void Recoil(float amount)
    {
        Vector2 force = astroScr.astroShootScr.bulletRb.velocity.normalized * amount;

        astroScr.rb.AddForce(force);
    }

    //Вращение персонажа
    internal void Rotate(Transform t, float amount)
    {
        t.Rotate(0, 0, amount);
    }
}

