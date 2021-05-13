using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : Enemy
{
    [Header("Scripts")]
    [SerializeField] internal TurretShoot turretShoot;
    [SerializeField] internal TurretGunTrack turretGunTrack;

    [Header("Turret variables")]
    [SerializeField] internal float fireRate = 3f;

    internal Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }
    
}
