using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroHandsChange : MonoBehaviour
{
    [SerializeField] AstroScript astroScr;

    private Animator anim;

    [SerializeField] AstroHandsRotate astroHands;
    [SerializeField] private Transform player;
    [SerializeField] private Transform firePoint;

    internal float angle;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        // flatten z axis
        astroHands.aimDir.z = 0;

        Vector3 neutralDir = player.up; //Присваивает neutralDir значение вектора поворота оси Y(зеленая координата). В отличии от Vector2.up учитывает вращение
        angle = Vector3.SignedAngle(neutralDir, astroHands.aimDir, Vector3.forward);

        Debug.Log("Angle: " + angle);

        if (angle > 150f || angle < -150f)
        {
            anim.SetBool("HandsDown", true);
            transform.localPosition = new Vector3(-0.045f, 0.139f, -19.19f);
            firePoint.localPosition = new Vector3(-0.332f, -0.043f, 21.56f);
        }
        else if (angle < 30f && angle > -30f)
        {
            anim.SetBool("HandsUp", true);
            transform.localPosition = new Vector3(-0.045f, 0.3f, -19.19f);
            firePoint.localPosition = new Vector3(-0.431f, 0.047f, 21.56f);
        }
        else
        {
            anim.SetBool("HandsDown", false);
            anim.SetBool("HandsUp", false);
            transform.localPosition = new Vector3(0.073f, 0.183f, -19.19f);
            firePoint.localPosition = new Vector3(-0.5f, 0.058f, 21.56f);
        }


        //anim.SetFloat("HandsAngle", angle);
    }
}
