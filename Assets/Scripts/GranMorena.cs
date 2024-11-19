using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranMorena : MonoBehaviour
{
    public Transform[] row1Points;        // Fila de puntos 1
    public Transform[] row2Points;        // Fila de puntos 2
    public float moveSpeed = 3f;          // Velocidad de movimiento del enemigo
    public float waitTimeMin = 1f;        // Tiempo m�nimo de espera en cada punto
    public float waitTimeMax = 3f;        // Tiempo m�ximo de espera en cada punto
    public float rotationSpeed = 5f;      // Velocidad de rotaci�n para que se oriente suavemente
    private bool isMoving = false;        // Bandera para controlar si el enemigo est� en movimiento

    void Start()
    {
        // Iniciar el movimiento con un retraso aleatorio
        StartCoroutine(StartMovementWithDelay());
    }

    IEnumerator StartMovementWithDelay()
    {
        // Retrasar el inicio del movimiento de este enemigo en un tiempo aleatorio
        float delayTime = Random.Range(0f, 3f); // Retraso aleatorio entre 0 y 3 segundos
        yield return new WaitForSeconds(delayTime);

        // Comenzar a moverse
        StartCoroutine(MoveToRandomPoint());
    }

    IEnumerator MoveToRandomPoint()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio antes de moverse
            float waitTime = Random.Range(waitTimeMin, waitTimeMax);
            yield return new WaitForSeconds(waitTime);

            // Determinar de qu� fila proviene el enemigo para seleccionar la fila opuesta
            Transform targetPoint;

            // Seleccionar aleatoriamente de la fila opuesta
            if (row1Points.Length > 0 && row2Points.Length > 0)
            {
                if (IsInRow(row1Points))
                {
                    // Si el enemigo est� en la fila 1, seleccionamos un punto aleatorio de la fila 2
                    targetPoint = row2Points[Random.Range(0, row2Points.Length)];
                }
                else
                {
                    // Si el enemigo est� en la fila 2, seleccionamos un punto aleatorio de la fila 1
                    targetPoint = row1Points[Random.Range(0, row1Points.Length)];
                }
            }
            else
            {
                // Si no hay puntos en las filas, salir del bucle
                yield break;
            }

            // Si ya estamos en movimiento, esperar a que termine
            if (isMoving)
                yield break;

            // Moverse al punto elegido
            isMoving = true;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = targetPoint.position;

            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            // Mientras el enemigo no haya llegado al punto de destino
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                // Mover al enemigo hacia el destino
                float distanceCovered = (Time.time - startTime) * moveSpeed;
                float fractionOfJourney = distanceCovered / journeyLength;

                // Movimiento hacia el objetivo
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

                // Rotar suavemente hacia el destino
                Vector3 direction = targetPosition - transform.position;
                if (direction != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(direction);  // Calcula la rotaci�n necesaria
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);  // Rotaci�n suave
                }

                yield return null;
            }

            // Asegurarse de que el enemigo llegue exactamente al destino
            transform.position = targetPosition;

            // Despu�s de llegar al destino, respawnear en un punto aleatorio de la misma fila
            if (IsInRow(row1Points))
            {
                transform.position = row1Points[Random.Range(0, row1Points.Length)].position;
            }
            else
            {
                transform.position = row2Points[Random.Range(0, row2Points.Length)].position;
            }

            // Despu�s de "respawnear" en un punto aleatorio de su fila, indicamos que ha terminado de moverse
            isMoving = false;
        }
    }

    // Comprobar si el enemigo est� dentro de la fila 1
    private bool IsInRow(Transform[] row)
    {
        foreach (Transform point in row)
        {
            if (Vector3.Distance(transform.position, point.position) < 0.1f)
                return true;
        }
        return false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            var healthComponent = collision.GetComponent<healthManager>();
            if (healthComponent != null)
            {
                healthComponent.TakeDamage(1);
            }
        }
    }
}

