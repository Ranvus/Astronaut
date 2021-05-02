using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroHandsAnimation : MonoBehaviour
{
    private Animator anim;

    [SerializeField] AstroHandsRotate astroRot;

    private bool isShoot;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        AnimUpdate();

        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("IsShoot");
        }
        else
        {
            isShoot = false;
        }
    }

    private void AnimUpdate()
    {
        anim.SetBool("IsShoot", isShoot);
        anim.SetFloat("Rotation", astroRot.angle);
    }
}
