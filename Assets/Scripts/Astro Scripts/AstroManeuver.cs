using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroManeuver : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Maneuver variables")]
    internal Vector2 mousePos;

    [Header("Other ref")]
    [SerializeField] internal Transform handRot;
    [SerializeField] internal Transform secondHandRot;
    [SerializeField] internal Transform firePointRot;

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

        if (!astroScr.astroAnimScr.bodyUp && !astroScr.astroAnimScr.bodyDown)
        {
            //Разворот персонажа в зависимости от расположения руки
            if (astroScr.astroHandsChScr.angle < 180f && astroScr.astroHandsChScr.angle > 0f)
            {
                transform.localScale = new Vector3(1, 1, 1);
                handRot.localScale = new Vector3(1, 1, 1);
                secondHandRot.localScale = new Vector3(1, 1, 1);
                firePointRot.localRotation = Quaternion.Euler(0, 0, 90);
            }
            else if (astroScr.astroHandsChScr.angle > -180f && astroScr.astroHandsChScr.angle < 0f)
            {
                transform.localScale = new Vector3(-1, 1, 1);
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(-1, 1, 1), Time.deltaTime);
                handRot.localScale = new Vector3(-1, -1, 1);
                secondHandRot.localScale = new Vector3(-1, -1, -1);
                firePointRot.localRotation = Quaternion.Euler(0, 180, 90);
            }
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