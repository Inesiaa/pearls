using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class piranha : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float rotationSpeed = 5f; // Velocidad de rotaci�n

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Mueve el objeto hacia el siguiente punto
        if (transform.position == patrolPoints[targetPoint].position)
        {
            increaseTargetInt();
        }

        // Movimiento hacia el siguiente punto
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[targetPoint].position, speed * Time.deltaTime);

        // Rotaci�n hacia el siguiente punto
        Vector3 direction = patrolPoints[targetPoint].position - transform.position;

        // Si la direcci�n no es cero, ajustamos la rotaci�n
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); // Calcula la rotaci�n
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Interpolaci�n suave
        }
    }

    // Incrementa el �ndice del punto objetivo
    void increaseTargetInt()
    {
        targetPoint++;
        if (targetPoint >= patrolPoints.Length)
        {
            targetPoint = 0;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            var healthComponent = collision.GetComponent<healthManager>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
                //Debug.Log("Collision");
            }
        }
    }
}
