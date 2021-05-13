using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : Enemy
{

    [SerializeField]
    float checkCircleRadius;

    [SerializeField]
    GameObject rightCheck, roofCheck, groundCheck;

    [SerializeField]
    float dirX = 1, dirY = .25f;

    private Rigidbody2D droneRb;
    [SerializeField] private LayerMask droneObstacleLayer;

    private bool facingRight = true, groundTouch, roofTouch, rightTouch;

    void Start()
    {
        droneRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        droneRb.velocity = new Vector2(dirX, dirY) * moveSpeed;
        HitDetection();
    }

    private void HitDetection()
    {
        rightTouch = Physics2D.OverlapCircle(rightCheck.transform.position, checkCircleRadius, droneObstacleLayer);
        roofTouch = Physics2D.OverlapCircle(roofCheck.transform.position, checkCircleRadius, droneObstacleLayer);
        groundTouch = Physics2D.OverlapCircle(groundCheck.transform.position, checkCircleRadius, droneObstacleLayer);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AstroScript character = collision.GetComponent<AstroScript>();
        if (collision.CompareTag("Character"))
        {
            character.rb.velocity = character.transform.position + (character.transform.position - transform.position).normalized * 0.6f;
        }
    }
}
