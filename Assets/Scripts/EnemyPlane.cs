using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlane : MonoBehaviour
{
    private float rangeX = 140;
    private float lowerBounds = -190;
    public GameObject bullet;

    [SerializeField] private float planeScore;
    [SerializeField] private float speed = 25;
    [SerializeField] private float bulletForce = 75;
    


    public virtual void ShootBullet(Vector3 offset)
    {
        if (!GameManager.Instance.isGameOver)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
            bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
        }
    }

    public virtual void ShootBullet(Vector3 offset,Vector3 target)
    {
        // POLYMORPHISM
        if (!GameManager.Instance.isGameOver)
        {
            GameObject bulletInstance = Instantiate(bullet, transform.position + offset, bullet.transform.rotation);
            Vector3 fireDirection = (target - bulletInstance.transform.position).normalized;
            bulletInstance.GetComponent<Rigidbody>().AddForce(fireDirection * bulletForce, ForceMode.Impulse);
        }
    }

    public void MovePlane()
    {
        // ABSTRACTION

        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public void CheckOutOfBounds()
    {
        // ABSTRACTION

        if (transform.position.x < -rangeX || transform.position.x > rangeX || transform.position.z < lowerBounds)
        {
            Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            if (!GameManager.Instance.isGameOver)
            {
                GameManager.Instance.score += planeScore;
            }
            Destroy(gameObject);
        }

    }
}
