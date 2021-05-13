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
    [SerializeField] internal AstroAnimation astroAnimScr;
    [SerializeField] internal AstroHandsChange astroHandsChScr;
    [SerializeField] internal AstroArrow astroArr;
    [SerializeField] internal AstroTakeDamage astroDmg;
    [SerializeField] internal AstroHandsRotate astroHandsRot;

    [Header("Player components")]
    internal Rigidbody2D rb;
    internal Camera cam;

    [Header("Astro move variables")]
    [SerializeField] internal float hp = 5f;

    [Header("Astro move variables")]
    [SerializeField] internal float clampVelocity = 3f;
    [SerializeField] internal float rotationSpeed = 5f;
    [SerializeField] internal float clampAngle = 90f;
    [SerializeField] internal float downLookAngle = 150f;
    [SerializeField] internal float upLookAngle = 30f;
    [SerializeField] internal float knockbackForce;

    [Header("Shoot variables")]
    [SerializeField] internal float bulletForce = 20f;

    [Header("Boolean variables")]
    internal bool canShoot = true;
    internal bool mouseRotationActive = true;
    internal bool isMove = false;

    [Header("References variables")]
    [SerializeField] internal GameObject arrow;
    [SerializeField] internal GameObject hand;
    [SerializeField] internal LayerMask obstacleLayer;
    [SerializeField] internal GameObject secondHand;

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
