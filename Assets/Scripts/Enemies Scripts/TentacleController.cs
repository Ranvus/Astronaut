using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : Enemy
{
    [Header("References")]
    private Transform character;
    private AudioSource tentaclSound;

    [Header("Animation variables")]
    private Animator anim;
    [SerializeField] internal bool characterIn;

    private float distanceFromPlayer;

    private void Start()
    {
        anim = GetComponent<Animator>();
        tentaclSound = GetComponent<AudioSource>();
        character = GameObject.FindGameObjectWithTag("Character").transform;
    }

    void Update()
    {
        if (character == null)
        {
            distanceFromPlayer = 0;
        }
        else
        {
            distanceFromPlayer = Vector2.Distance(character.position, transform.position);
        }

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

    private void TentacleSound()
    {
        tentaclSound.Play();
    }

    private void AnimUpdate()
    {
        anim.SetBool("CharacterIn", characterIn);
        anim.SetFloat("TentacleHp", curHp);
    }

    protected override void TakeDamage(int damage)
    {
        if (characterIn)
        {
            sr.material = matFlash; 
            StartCoroutine(DeathFlash());
            curHp -= damage;
        }
        if (curHp <= 0)
        {
            Death();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
        
    }

    protected override void Death()
    {
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + .5f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
