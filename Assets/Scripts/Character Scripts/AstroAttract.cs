using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttract : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private bool isTouchingObstacle;
    internal bool cling;
    [SerializeField] private LayerMask whatIsObstacle;
    private Vector3 posCur;
    private Quaternion rotCur;

    [SerializeField] internal GameObject arrow;

    private void Start()
    {
        print("Astro Attrac");
        astroScr.rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Update()
    {
        RaycastHit2D hit = new RaycastHit2D();
        hit = Physics2D.Raycast(transform.position, transform.TransformDirection(-Vector3.up), .4f, whatIsObstacle);
        if (hit.collider.tag == "Obstacle")
        {
            isTouchingObstacle = true;
        }
        else
        {
            isTouchingObstacle = false;
        }

        rotCur = Quaternion.FromToRotation(Vector3.up, hit.normal);
        posCur = new Vector3(transform.position.x, hit.point.y, transform.position.z);

        if (isTouchingObstacle && (Input.GetButtonDown("Fire2")))
        {
            astroScr.rb.velocity = Vector2.zero;
            astroScr.canShoot = false;
            astroScr.mouseRotationActive = false;
            cling = true;

            transform.rotation = Quaternion.Lerp(transform.rotation, rotCur, 5f);
            astroScr.rb.AddForce(posCur * 10f);
            astroScr.rb.drag = 5f;

            arrow.SetActive(true);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.TransformDirection(0f, -0.4f, 0f));
    }
}
