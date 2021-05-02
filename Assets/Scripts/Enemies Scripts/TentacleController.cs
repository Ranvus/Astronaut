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


    [Header("References")]
    private Transform character;

    [Header("Animation variables")]
    private Animator anim;
    [SerializeField] private bool characterIn;

    [Header("Tentacle variables")]
    [SerializeField] private float attackRange;
    [SerializeField] private float tentacleHp;



    private void Start()
    {
        /*nextPos = startPos.position;
        currentTime = delay;*/
        anim = GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("Character").transform;
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

        float distanceFromPlayer = Vector2.Distance(character.position, transform.position);

        if (distanceFromPlayer <= attackRange)
        {
            characterIn = true;
        }
        else if (distanceFromPlayer >= attackRange)
        {
            characterIn = false;
        }

        AnimUpdate();
    }

    private void AnimUpdate()
    {
        anim.SetBool("CharacterIn", characterIn);
        anim.SetFloat("TentacleHp", tentacleHp);
    }

    internal void TakeDamage(int damage)
    {
        if (characterIn)
        {
            tentacleHp -= damage;
        }
        if (tentacleHp <= 0)
        {
            Death();
        }
    }

    private void Death()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + .5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
