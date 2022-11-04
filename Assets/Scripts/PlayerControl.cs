using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRB;
    [SerializeField] private float speed = 10;
    private float rangeLimitY = 125;
    private float rangeLimitX = 100;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }

    void MovePlayer()
    {
        //Abstraction

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 currentPos = transform.position;
        //up and down movement
        if (transform.position.z < rangeLimitY && transform.position.z > -rangeLimitY)
        {
            transform.Translate(Vector3.forward * verticalInput * speed * Time.deltaTime);
        }
        // left and right movement
        if (transform.position.x <= rangeLimitX && transform.position.x >= -rangeLimitX)
        {
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        }
        else
        {
            transform.position = currentPos;
        }
    }
}
