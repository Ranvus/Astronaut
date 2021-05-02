using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacehuggerMovement : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] FacehuggerScript faceScr;

    [Header("Obstacle Check variables")]
    [SerializeField]
    private bool groundDetected, wallDetected;
    [SerializeField]
    private Transform groundCheck, wallCheck;
    [SerializeField] private float checkDistance;

    [Header("Move variables")]
    private bool hasTurn;
    internal bool isMove = true;
    private float ZaxiesAdd;
    private int direction;

    [SerializeField] private LayerMask faceObstacleLayer;

    void Start()
    {
        hasTurn = false;
        direction = 1;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            CheckGroundOrWall();
            Movement();
        }
    }

    private void CheckGroundOrWall()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, -transform.up, checkDistance, faceObstacleLayer);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, checkDistance, faceObstacleLayer);

        if (!groundDetected)
        {
            if (hasTurn == false)
            {
                ZaxiesAdd -= 90;
                transform.eulerAngles = new Vector3(0, 0, ZaxiesAdd);
                if (direction == 1)
                {
                    transform.position = new Vector2(transform.position.x + 0.25f, transform.position.y - 0.2f);
                    hasTurn = true;
                    direction = 2;
                }
                else if (direction == 2)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y - 0.3f);
                    hasTurn = true;
                    direction = 3;
                }
                else if (direction == 3)
                {
                    transform.position = new Vector2(transform.position.x - 0.3f, transform.position.y + 0.2f);
                    hasTurn = true;
                    direction = 4;
                }
                else if (direction == 4)
                {
                    transform.position = new Vector2(transform.position.x + 0.3f, transform.position.y + 0.3f);
                    hasTurn = true;
                    direction = 1;
                }
            }
        }

        if (groundDetected)
        {
            hasTurn = false;
        }

        if (wallDetected)
        {
            if (hasTurn == false)
            {
                ZaxiesAdd += 90;
                transform.eulerAngles = new Vector3(0, 0, ZaxiesAdd);
                if (direction == 1)
                {
                    transform.position = new Vector2(transform.position.x - 0.2f, transform.position.y + 0.2f);
                    hasTurn = true;
                    direction = 4;
                }
                else if (direction == 2)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y + 0.2f);
                    hasTurn = true;
                    direction = 1;
                }
                else if (direction == 3)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f);
                    hasTurn = true;
                    direction = 2;
                }
                else if (direction == 4)
                {
                    transform.position = new Vector2(transform.position.x + 0.2f, transform.position.y - 0.2f);
                    hasTurn = true;
                    direction = 3;
                }
            }
        }
    }

    private void Movement()
    {
        faceScr.facehuggerRb.velocity = transform.right * faceScr.facehuggerSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - checkDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + checkDistance, wallCheck.position.y));
    }
}
