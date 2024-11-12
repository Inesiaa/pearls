using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Crabs : MonoBehaviour
{
    public Transform Target;
    public float UpdateSpeed = 0.1f;
    public float detectionRange = 10f;

    private NavMeshAgent Agent;
    private bool isPlayerInRange = false;


    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        //StartCoroutine(FollowTarget());
    }

    void Update()
    {
        // Verificar si el jugador est� dentro del rango de detecci�n
        float distanceToPlayer = Vector3.Distance(transform.position, Target.position);
        if (distanceToPlayer <= detectionRange)
        {
            isPlayerInRange = true;
        }
        else
        {
            isPlayerInRange = false;
        }

        // Si el jugador est� dentro del rango, perseguirlo
        if (isPlayerInRange)
        {
            StartCoroutine(FollowTarget());
        }
        else
        {
            StopAllCoroutines();
        }
    }

    private IEnumerator FollowTarget()
    {
        WaitForSeconds Wait = new WaitForSeconds(UpdateSpeed);

        while (true)
        {
            Agent.SetDestination(Target.transform.position);
            yield return Wait;
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


    //public Transform player;                // Referencia al jugador
    //public float detectionRange = 10f;      // Rango de detecci�n del jugador
    //public float moveSpeed = 3f;            // Velocidad de movimiento del enemigo
    //public Vector3 areaMin;                 // Coordenadas m�nimas del �rea
    //public Vector3 areaMax;                 // Coordenadas m�ximas del �rea

    //private bool isPlayerInRange = false;

    //void Update()
    //{
    //    // Verificar si el jugador est� dentro del rango de detecci�n
    //    float distanceToPlayer = Vector3.Distance(transform.position, player.position);
    //    if (distanceToPlayer <= detectionRange)
    //    {
    //        isPlayerInRange = true;
    //    }
    //    else
    //    {
    //        isPlayerInRange = false;
    //    }

    //    // Si el jugador est� dentro del rango, perseguirlo
    //    if (isPlayerInRange)
    //    {
    //        MoveTowardsPlayer();
    //    }
    //}

    //// Funci�n para mover al enemigo hacia el jugador
    //void MoveTowardsPlayer()
    //{
    //    // Calcular la direcci�n hacia el jugador
    //    Vector3 direction = (player.position - transform.position).normalized;

    //    // Mover al enemigo hacia la posici�n deseada
    //    Vector3 targetPosition = transform.position + direction * moveSpeed * Time.deltaTime;

    //    // Restringir el movimiento dentro del �rea
    //    targetPosition.x = Mathf.Clamp(targetPosition.x, areaMin.x, areaMax.x);
    //    targetPosition.y = Mathf.Clamp(targetPosition.y, areaMin.y, areaMax.y);
    //    targetPosition.z = Mathf.Clamp(targetPosition.z, areaMin.z, areaMax.z);

    //    // Actualizar la posici�n del enemigo
    //    transform.position = targetPosition;
    //}
}
