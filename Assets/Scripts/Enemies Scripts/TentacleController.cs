using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleController : Enemy
{
    [Header("References")]
    private Transform character;

    [Header("Animation variables")]
    private Animator anim;
    [SerializeField] internal bool characterIn;

    private void Start()
    {
        anim = GetComponent<Animator>();
        character = GameObject.FindGameObjectWithTag("Character").transform;
    }

    void Update()
    {
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AstroScript character = collision.GetComponent<AstroScript>();
        if (collision.CompareTag("Character"))
        {
            character.rb.AddForce(-character.rb.velocity.normalized * character.knockbackForce, ForceMode2D.Impulse);
        }
    }
}
