using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //Public Variables\\
    public bool isGrounded = false;
    public Vector3 velocity;
    public float gravity = -9.8f;
    public float speed;
    public float jump = 10f;
    //Private Variables\\

    private Rigidbody rb;

    //Initiate at first frame of game\\

    void Start()
    {
        //Calling Components\\
        isGrounded = true;
        rb = GetComponent<Rigidbody>();
    }

    //Initiate at a set time\\

    void Update()
    {
        //Movement Controls\\
        if (Input.GetButtonDown ("Jump") && isGrounded == true)
        {
            rb.AddForce(Vector3.up * jump);
            isGrounded = false;
        }
        else
        {
            velocity.y += gravity * Time.deltaTime;
            isGrounded = true;
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    //Pick-up Collision\\

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
        }
    }
}