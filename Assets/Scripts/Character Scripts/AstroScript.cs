using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] internal AstroInput astroInputScr;
    [SerializeField] internal AstroManeuver astroManScr;
    [SerializeField] internal AstroShoot astroShootScr;
    [SerializeField] internal AstroCollision astroColScr;
    [SerializeField] internal AstroAttract astroAttractScr;

    [Header("Components")]
    internal Rigidbody2D rb;
    internal Camera cam;

    [Header("Ship variables")]
    [SerializeField] internal float maxVelocity = 3f;
    [SerializeField] internal float rotationSpeed = 1f;
    [SerializeField] internal float bulletForce = 20f;

    [Header("Boolean variables")]
    internal bool canShoot = true;
    internal bool mouseRotationActive = true;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = GetComponent<Camera>();
    }

    private void Start()
    {
        print("Astro Script");
    }
}
