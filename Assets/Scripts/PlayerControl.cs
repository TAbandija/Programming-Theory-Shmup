using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float speed = 10;
    [SerializeField] private float bulletForce = 100;
    private float rangeLimitY = 150;
    private float rangeLimitX = 100;
    private Vector3 bulletOffSet;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        bulletOffSet = new Vector3(0, 0, 10);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
        }

    }

    void ShootBullet()
    {
        // ABSTRACTION

        GameObject bulletInstance = Instantiate(bullet, transform.position + bulletOffSet, bullet.transform.rotation);
        bulletInstance.GetComponent<Rigidbody>().AddForce(transform.forward * bulletForce, ForceMode.Impulse);
    }

    void MovePlayer()
    {
        //Abstraction

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 currentPos = transform.position;
        //up and down movement
        transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);

        // left and right movement
        transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        //Checks if player is out of Bounds
        if (CheckOutOfBounds())
        {
            transform.position = currentPos;
        }
    }

    bool CheckOutOfBounds()
    {
        // ABSTRACTION

        bool isOutOfBounds;

        isOutOfBounds = transform.position.z > rangeLimitY || transform.position.z < -rangeLimitY || transform.position.x > rangeLimitX || transform.position.x < -rangeLimitX;

        return isOutOfBounds;
    }

    void PlayerHit()
    {
        // ABSTRACTION
        Debug.Log("Player hit");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EnemyBullet"))
        {
            PlayerHit();
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        PlayerHit();
    }
}
