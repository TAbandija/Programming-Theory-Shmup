using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlBoss : EnemyPlane
{
    // INHERITANCE

    private float startFiring = 1.0f;
    private Vector3 gunOffset1;
    private Vector3 gunOffset2;
    private Vector3 gunOffsetMain;
    private float rateOfFire = 1.6f;
    private float rateOfFireMain = 1.2f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gunOffset1 = new Vector3(-12, 0, -10);
        gunOffset2 = new Vector3(12, 0, -10);
        gunOffsetMain = new Vector3(0, 0, -26);
        InvokeRepeating("FireGun", startFiring, rateOfFire);
        InvokeRepeating("FireGunMain", startFiring, rateOfFireMain);
    }

    private void Update()
    {
        MovePlane();
        CheckOutOfBounds();
    }

    private void FireGun()
    {
        ShootBullet(gunOffset1);
        ShootBullet(gunOffset2);
    }

    private void FireGunMain()
    {
        ShootBullet(gunOffsetMain, player.transform.position);
    }
}
