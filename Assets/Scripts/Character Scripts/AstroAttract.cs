using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroAttract : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private bool isTouchingObstacle;
    [SerializeField] private float checkRadius = 0.5f;
    [SerializeField] private Vector2 obstacleCheckSize;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform obstacleCheck;
    [SerializeField] private LayerMask whatIsObstacle;
    private int[] isTouching;

    [SerializeField] private GameObject obstacle;

    internal bool cling;

    //internal bool canShoot = true;

    private void Start()
    {
        print("Astro Attrac");
    }

    private void Update()
    {
        Vector2 boxPosition = transform.position;
        Vector2 boxSize = obstacleCheckSize;
        //isTouchingObstacle = Physics2D.OverlapCircle(obstacleCheck.position, checkRadius, whatIsObstacle);
        //isTouchingObstacle = Physics2D.OverlapBox(Vector3.zero + offset, obstacleCheckSize, this.transform.rotation.z, whatIsObstacle);
        Collider[] isTouchingObstacle = Physics.OverlapBox(Vector3.zero + offset, obstacleCheckSize * 0.5f, transform.rotation, whatIsObstacle);
        print(isTouchingObstacle.Length);
        if (isTouchingObstacle.Length > 0 && (Input.GetButtonDown("Fire2")))
        {
            astroScr.rb.velocity = new Vector2(0, 0);
            astroScr.canShoot = false;
            astroScr.mouseRotationActive = false;
            cling = true;
            //transform.position = Vector2.Lerp(this.transform.position, obstacle.transform.position, 3f);
        }
        else if(isTouchingObstacle.Length == 0 && (Input.GetButtonUp("Fire2")))
        {
            astroScr.canShoot = true;
            astroScr.mouseRotationActive = true;
            cling = false;
        }
    }

    private void OnDrawGizmos()
    {
        /*Color prevColor = Gizmos.color;
        Matrix4x4 prevMatrix = Gizmos.matrix;

        Gizmos.color = Color.red;
        Gizmos.matrix = transform.localToWorldMatrix;

        Vector2 boxPosition = transform.position;

        // convert from world position to local position 
        boxPosition = transform.InverseTransformPoint(boxPosition);

        Vector2 boxSize = obstacleCheckSize;*/

        /*Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawCube(Vector3.zero + offset, obstacleCheckSize);*/
        
        Gizmos.matrix = this.transform.localToWorldMatrix;
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(Vector3.zero + offset, obstacleCheckSize);

        // restore previous Gizmos settings
        /*Gizmos.color = prevColor;
        Gizmos.matrix = prevMatrix;*/
    }
}
