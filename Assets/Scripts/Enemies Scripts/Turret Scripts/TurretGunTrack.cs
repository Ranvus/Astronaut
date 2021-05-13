using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretGunTrack : MonoBehaviour
{
    [SerializeField] TurretScript turretScr;

    private Animator anim;

    private bool playerIn;
    internal Quaternion turretGunRot;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 turretGunDir = turretScr.player.position - transform.position;
        float turretGunAngle = Mathf.Atan2(turretGunDir.y, turretGunDir.x) * Mathf.Rad2Deg - 180f;
        turretGunRot = Quaternion.AngleAxis(turretGunAngle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, turretGunRot, 5f * Time.deltaTime);

        float distanceFromPlayer = Vector2.Distance(turretScr.player.position, transform.position);

        if (distanceFromPlayer <= turretScr.attackRange)
        {
            playerIn = true;
        }
        else if (distanceFromPlayer >= turretScr.attackRange)
        {
            playerIn = false;
        }

        anim.SetBool("PlayerIn", playerIn);
    }
}
