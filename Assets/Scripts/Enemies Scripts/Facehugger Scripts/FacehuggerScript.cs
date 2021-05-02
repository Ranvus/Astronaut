using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacehuggerScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] internal FacehuggerMovement faceMove;

    [Header("Facehugger components")]
    internal Rigidbody2D facehuggerRb;

    [Header("Facehugger variables")]
    [SerializeField] internal float facehuggerSpeed;
    [SerializeField] internal float facehuggerForce;
    //[SerializeField] internal float attackRange;
    internal float distanceFromPlayer;

    [Header("Other objects references")]
    internal Transform player;

    private void Awake()
    {
        facehuggerRb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }

    private void Start()
    {
        print("Face Script");
    }
}
