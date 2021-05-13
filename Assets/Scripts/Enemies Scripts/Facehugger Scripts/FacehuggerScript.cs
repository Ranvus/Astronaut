using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacehuggerScript : Enemy
{
    [Header("Scripts")]
    [SerializeField] internal FacehuggerMovement faceMove;

    [Header("Facehugger components")]
    internal Rigidbody2D facehuggerRb;

    [Header("Other objects references")]
    internal Transform player;
    [SerializeField] private Material faceFlash;

    private void Awake()
    {
        curHp = maxHp;
        facehuggerRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Character").transform;
        matDefault = sr.material;
    }

    private void Start()
    {
        print("Face Script");
    }

    private void Update()
    {
        print(curHp);
        print(attackRange);
    }

    protected override void TakeDamage(int damage)
    {
        sr.material = faceFlash;
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

    protected override void Death()
    {
        Destroy(gameObject);
    }
}
