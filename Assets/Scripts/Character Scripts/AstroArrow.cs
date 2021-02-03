using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroArrow : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    //private Rigidbody2D arrowRb;
    private Vector2 arrowMousePos;

    // Start is called before the first frame update
    void Start()
    {
        //arrowRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (astroScr.astroAttractScr.cling)
        {
            gameObject.SetActive(true);
        }

        arrowMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 lookDir = arrowMousePos - new Vector2(transform.position.x, transform.position.y);
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg + 90f;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
