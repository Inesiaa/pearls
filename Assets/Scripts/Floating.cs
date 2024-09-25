using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floating : MonoBehaviour
{
    public float speed = 10f;
    public float jumpSpeed = 10f;
    //Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //rb.AddForce(0, 11f, 0);
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3 (horizontal * speed * Time.deltaTime, vertical * speed * Time.deltaTime);
        //rb.MovePosition (transform.position + movement);
    }
}
