using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    [Header("Scripts")]
    [SerializeField] internal TurretShoot turretShoot;
    [SerializeField] internal TurretGunTrack turretGunTrack;

    [SerializeField] internal float shootingRange;
    [SerializeField] internal float fireRate = 3f;

    internal Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Character").transform;
    }
    
}
