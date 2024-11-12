using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;            // Velocidad de movimiento
    public float jumpForce = 7f;            // Fuerza de salto
    public LayerMask groundLayer;           // Capa que define el suelo
    public float groundCheckDistance = 0.1f; // Distancia para comprobar si est� tocando el suelo

    private Rigidbody rb;                   // Componente Rigidbody del jugador
    private bool isGrounded;                // Si el jugador est� tocando el suelo

    void Start()
    {
        // Obtener el componente Rigidbody
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Verificar si el jugador est� tocando el suelo
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundCheckDistance, groundLayer);

        // Mover al jugador
        MovePlayer();

        // Hacer que el jugador mire hacia el rat�n
        LookAtMouse();

        // Saltar si el jugador est� en el suelo y presiona la tecla de salto (espacio)
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    // M�todo para mover al jugador
    void MovePlayer()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A/D o flechas izquierda/derecha
        float vertical = Input.GetAxis("Vertical");     // W/S o flechas arriba/abajo

        Vector3 moveDirection = new Vector3(horizontal, 0f, vertical).normalized;

        // Aplicar el movimiento al Rigidbody
        rb.MovePosition(transform.position + moveDirection * moveSpeed * Time.deltaTime);
    }

    // M�todo para hacer que el jugador mire hacia donde est� el rat�n
    void LookAtMouse()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  // Crear un rayo hacia la posici�n del rat�n
        RaycastHit hit;

        // Si el rayo golpea algo en el mundo 3D, gira al jugador hacia ese punto
        if (Physics.Raycast(ray, out hit))
        {
            Vector3 lookDirection = hit.point - transform.position;
            lookDirection.y = 0;  // Solo rotar en el eje Y
            transform.rotation = Quaternion.LookRotation(lookDirection);
        }
    }

    // M�todo para hacer saltar al jugador
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Salto hacia arriba
    }
}
