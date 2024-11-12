using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMovement : MonoBehaviour
{
    //public float FollowSpeed = 2f;
    //public float yOffSet = 1f;
    //public Transform target;

    //// Update is called once per frame
    //void Update()
    //{
    //    Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);
    //    transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    //}

    public Transform player;        // El jugador a seguir
    public float smoothSpeed = 0.125f;  // Velocidad de suavizado (ajusta este valor)
    public Vector3 offset;         // Desplazamiento de la cámara (por ejemplo, por encima del jugador)

    void LateUpdate()
    {
        // Calcula la posición deseada de la cámara
        Vector3 desiredPosition = player.position + offset;

        // Suaviza el movimiento entre la posición actual y la deseada usando Lerp
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Establece la nueva posición de la cámara
        transform.position = smoothedPosition;
    }
}
