using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroManeuver : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [Header("Maneuver variables")]
    internal Vector2 mousePos;
    internal float angle;
    internal float astroRot;
    
    private void Start()
    {
        print("Astro Man");
    }

    private void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        astroScr.astroManScr.ClampVelocity();

        if (astroScr.mouseRotationActive)
        {
            Vector2 lookDir = mousePos - astroScr.rb.position;
            float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
            transform.rotation = Quaternion.Euler(0, 0, angle);
            astroRot = transform.rotation.z;
        }
    }

    internal void ClampVelocity()
    {
        float x = Mathf.Clamp(astroScr.rb.velocity.x, -astroScr.maxVelocity, astroScr.maxVelocity);
        float y = Mathf.Clamp(astroScr.rb.velocity.y, -astroScr.maxVelocity, astroScr.maxVelocity);

        astroScr.rb.velocity = new Vector2(x, y);
    }

    internal void ThrustForward(float amount)
    {
        Vector2 force = transform.up * amount;

        astroScr.rb.AddForce(force);
    }
}
