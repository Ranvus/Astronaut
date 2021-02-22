using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroArrow : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;
    public Transform player;

    //private Rigidbody2D arrowRb;
    private Vector3 arrowMousePos;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        arrowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = arrowMousePos - new Vector3(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        Vector2 dashDir = arrowMousePos - player.position;

        if (Input.GetButtonDown("Fire1"))
        {
            astroScr.rb.drag = 0f;
            astroScr.rb.velocity = Vector2.zero;
            //astroScr.rb.velocity += arrowMousePos.normalized * 10f;
            astroScr.rb.AddForce(dashDir.normalized * 15f, ForceMode2D.Impulse);
            astroScr.canShoot = true;
            astroScr.mouseRotationActive = true;
            astroScr.astroAttractScr.cling = false;
            astroScr.astroAttractScr.arrow.SetActive(false);

            print(astroScr.canShoot);
            print(astroScr.mouseRotationActive);
            print(astroScr.astroAttractScr.cling);
        }
    }

    /*private void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            astroScr.rb.drag = 0f;
            Vector2 mouseDirection = (Input.mousePosition - new Vector3(Screen.width / 2, Screen.height / 2)).normalized;
            astroScr.rb.AddForce(mouseDirection * 200000 * Time.fixedDeltaTime);
            astroScr.canShoot = true;
            astroScr.mouseRotationActive = true;
            astroScr.astroAttractScr.cling = false;
            astroScr.astroAttractScr.arrow.SetActive(false);
            
        }
    }*/
}
