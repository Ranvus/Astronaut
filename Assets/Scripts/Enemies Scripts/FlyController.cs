using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyController : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    [SerializeField]
    float flySpeed, checkCircleRadius;

    [SerializeField]
    GameObject rightCheck, roofCheck, groundCheck;

    [SerializeField]
    float dirX = 1, dirY = .25f;

    private Rigidbody2D flyRb;

    private bool facingRight = true, groundTouch, roofTouch, rightTouch;

    void Start()
    {
        flyRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        flyRb.velocity = new Vector2(dirX, dirY) * flySpeed;
        HitDetection();
    }

    private void HitDetection()
    {
        rightTouch = Physics2D.OverlapCircle(rightCheck.transform.position, checkCircleRadius, astroScr.obstacleLayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, checkCircleRadius, astroScr.obstacleLayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, checkCircleRadius, astroScr.obstacleLayer);
        HitLogic();
    }

    private void HitLogic()
    {
        if (rightTouch && facingRight)
        {
            Flip();
        }
        else if (rightTouch && !facingRight)
        {
            Flip();
        }

        if (roofTouch)
        {
            dirY = -0.25f;
        }
        else if (groundTouch)
        {
            dirY = 0.25f;
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(new Vector3(0, 180, 0));
        dirX = -dirX;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(rightCheck.transform.position, checkCircleRadius);
        Gizmos.DrawWireSphere(roofCheck.transform.position, checkCircleRadius);
        Gizmos.DrawWireSphere(groundCheck.transform.position, checkCircleRadius);
    }
}
