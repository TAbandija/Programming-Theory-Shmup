using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    private float rangeX = 140;
    private float lowerBounds = -190;
    private Rigidbody bulletRB;
    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //bulletRB.AddForce()
    }

    private void Update()
    {
        CheckOutOfBounds();
    }
    public void CheckOutOfBounds()
    {
        if (transform.position.x < -rangeX || transform.position.x > rangeX || transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
