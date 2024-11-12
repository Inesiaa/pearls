using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morenas : MonoBehaviour
{
    public Transform[] points;            // Puntos a los que los enemigos se moverán (destinos predefinidos)
    public float moveSpeed = 3f;          // Velocidad de movimiento del enemigo
    public float waitTimeMin = 1f;        // Tiempo mínimo de espera en cada punto
    public float waitTimeMax = 3f;        // Tiempo máximo de espera en cada punto
    private Vector3 initialPosition;      // Posición inicial del enemigo
    private bool isMoving = false;        // Bandera para controlar si el enemigo está en movimiento

    void Start()
    {
        // Guardamos la posición inicial del enemigo
        initialPosition = transform.position;

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

            // Escoger un punto aleatorio entre los puntos disponibles
            Transform targetPoint = points[Random.Range(0, points.Length)];

            // Si ya estamos en movimiento, esperar a que termine
            if (isMoving)
                yield break;

            // Moverse al punto elegido
            isMoving = true;
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = targetPoint.position;

            float journeyLength = Vector3.Distance(startPosition, targetPosition);
            float startTime = Time.time;

            // Mover al enemigo a su destino
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                float distanceCovered = (Time.time - startTime) * moveSpeed;
                float fractionOfJourney = distanceCovered / journeyLength;
                transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);
                yield return null;
            }

            // Asegurarse de que el enemigo llegue exactamente al destino
            transform.position = targetPosition;

            // Respawn al punto original después de llegar a cualquier punto
            //yield return new WaitForSeconds(Random.Range(waitTimeMin, waitTimeMax)); // Espera aleatoria en el punto de destino
            transform.position = initialPosition; // Regresar al punto original

            // Una vez llegado a su posición inicial, indicamos que ha terminado de moverse
            isMoving = false;
        }
    }
}
