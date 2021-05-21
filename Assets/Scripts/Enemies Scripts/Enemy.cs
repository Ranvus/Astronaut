using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] internal float moveSpeed;
    [SerializeField] internal int curHp;
    [SerializeField] internal int maxHp;
    [SerializeField] internal float attackRange;
    [SerializeField] internal int enemyDmg;
    [SerializeField] internal float knockbackForce;

    internal Material matFlash;
    internal Material matDefault;
    internal SpriteRenderer sr;

    private AstroTakeDamage characterDmg;

    private void Awake()
    {
        curHp = maxHp;
        sr = GetComponent<SpriteRenderer>();
        matFlash = Resources.Load("Flash", typeof(Material)) as Material;
        matDefault = sr.material;
        characterDmg = GameObject.FindGameObjectWithTag("Character").GetComponent<AstroTakeDamage>();

    }

    protected virtual void TakeDamage(int damage)
    {
        sr.material = matFlash;
        curHp -= damage;

        if (curHp <= 0)
        {
            StartCoroutine(DeathFlash());
            Death();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }

    }
    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }

    internal IEnumerator DeathFlash()
    {
        yield return new WaitForSeconds(.2f);
        sr.material = matDefault;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Bullet bullet = collision.GetComponent<Bullet>();

        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(bullet.astroDmg);
        }

        Rigidbody2D character = collision.GetComponent<Rigidbody2D>();
        if (collision.CompareTag("Character"))
        {
            Vector2 difference = character.transform.position - transform.position;
            difference = difference.normalized * knockbackForce;
            character.AddForce(difference, ForceMode2D.Impulse);
            CinemachineShake.Instance.ShakeCamera(.5f, .1f);
            characterDmg.TakeDamage(enemyDmg);
        }
    }
}
