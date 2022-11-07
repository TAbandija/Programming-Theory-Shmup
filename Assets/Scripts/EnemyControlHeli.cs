using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControlHeli : EnemyPlane
{
    // INHERITANCE

    private float startFiring = 1.0f;
    private Vector3 gunOffset;
    [SerializeField] float rateOfFire = 1.3f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gunOffset = new Vector3(0, 0, -14);
        InvokeRepeating("FireGun", startFiring, rateOfFire);
    }

    private void Update()
    {
        MovePlane();
        CheckOutOfBounds();
    }

    private void FireGun()
    {
        ShootBullet(gunOffset,player.transform.position);
    }
}
