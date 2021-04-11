using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacehuggerAttack : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] FacehuggerScript faceScr;
    [SerializeField] AstroScript astroScr;

    internal float playerPosX;
    internal float playerPosY;

    private bool facingRight = true;

    void Update()
    {
        faceScr.distanceFromPlayer = Vector2.Distance(faceScr.player.position, transform.position);

        /*if (faceScr.distanceFromPlayer <= faceScr.attackRange)
        {
            faceScr.faceMove.isMove = false;
            StartCoroutine(FacehuggerJump());
        }*/
    }

    private void FixedUpdate()
    {
        if (faceScr.faceMove.isMove == false)
        {
            FlipTowardsPlayer();
        }
    }

    private void FlipTowardsPlayer()
    {
        playerPosX = faceScr.player.position.x - transform.position.x;
        playerPosY = faceScr.player.position.y - transform.position.y;
        if (playerPosX < 0 && facingRight)
        {
            Flip();
        }
        else if (playerPosX > 0 && !facingRight)
        {
            Flip();
        }

        print(faceScr.player.rotation.z);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 50);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Character"))
        {
            faceScr.facehuggerRb.bodyType = RigidbodyType2D.Kinematic;
        }
    }

    IEnumerator FacehuggerJump()
    {
        faceScr.facehuggerRb.velocity = Vector2.zero;
        faceScr.facehuggerRb.bodyType = RigidbodyType2D.Dynamic;
        faceScr.facehuggerRb.gravityScale = 0;
        faceScr.facehuggerRb.mass = 0.1f;

        yield return new WaitForSeconds(.000001f);

        faceScr.facehuggerRb.AddForce((faceScr.player.position - transform.position).normalized * faceScr.facehuggerForce * Time.deltaTime);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        //Gizmos.DrawWireSphere(transform.position, faceScr.attackRange);
    }
}
