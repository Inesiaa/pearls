using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class crabsScripts : MonoBehaviour
{
    public Transform target;
    public float enemySpeed = 1f;
    Rigidbody rb;
    
    void Update()
    {
        
    }

    private void OnTriggerEnter
        (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);
            rb.MovePosition(pos);
            transform.LookAt(target);

            Debug.Log("isTrigger");
        }
    }
}
