using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : MonoBehaviour
{
    /*[SerializeField] private Transform pos1, pos2;
    [SerializeField] private float speed;
    [SerializeField] private Transform startPos;

    private Vector3 nextPos;
    [SerializeField] private float delay;
    private float currentTime;*/

    private Animator anim;

    [SerializeField] private Transform player;

    [SerializeField] private bool playerIn;
    [SerializeField] private float attackRange;

    private void Start()
    {
        /*nextPos = startPos.position;
        currentTime = delay;*/
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        /*if (transform.position == pos1.position)
        {
            currentTime -= Time.deltaTime;
            if (currentTime <= 0f)
            {
                nextPos = pos2.position;
                currentTime = delay;
            }
            print(currentTime);
        }
        if (transform.position == pos2.position)
        {
            nextPos = pos1.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);*/

        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer <= attackRange)
        {
            playerIn = true;
        }
        else if (distanceFromPlayer >= attackRange)
        {
            playerIn = false;
        }

        AnimUpdate();
    }

    private void AnimUpdate()
    {
        anim.SetBool("PlayerIn", playerIn);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
