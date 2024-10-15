using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float rotationSpeed = 100.0f;

    public float jumpSpeed = 1f;
    public Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        //float jump = Input.GetButtonDown("Jump") * Time.deltaTime * jumpSpeed;


        translation *= Time.deltaTime; // Make it move 10 meters per second instead of 10 meters per frame...
        rotation *= Time.deltaTime;

        transform.Translate(0, 0, translation); // Move translation along the object's z-axis

        transform.Rotate(0, rotation, 0); //Rotate around our y-axis  

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 50);
        }
    }
}
