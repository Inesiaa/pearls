using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class piranha : MonoBehaviour
{
    public Transform[] patrolPoints;
    public int targetPoint;
    public float speed;
    public float rotationSpeed = 5f; // Velocidad de rotación

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

        // Rotación hacia el siguiente punto
        Vector3 direction = patrolPoints[targetPoint].position - transform.position;

        // Si la dirección no es cero, ajustamos la rotación
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); // Calcula la rotación
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // Interpolación suave
        }
    }

    // Incrementa el índice del punto objetivo
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
