using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    private float rangeX = 140;
    private float lowerBounds = -190;
    public GameObject bullet;

    [SerializeField] private float speed = 25;
    [SerializeField] private float bulletForce = 10;
    


    public virtual void ShootBullet(Vector3 offset)
    {
        GameObject bulletInstance = Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
    }

    public virtual void ShootBullet(Vector3 offset,Vector3 target)
    {
        // POLYMORPHISM
        GameObject bulletInstance = Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
        Vector3 fireDirection = (target - bulletInstance.transform.position).normalized;
        bulletInstance.GetComponent<Rigidbody>().AddForce(fireDirection * bulletForce, ForceMode.Impulse);
    }

    public void MovePlane()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void CheckOutOfBounds()
    {
        if (transform.position.x < -rangeX || transform.position.x > rangeX || transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
