using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad del jugador
    private Rigidbody2D rb;
    private Vector2 movement;
    private SpriteRenderer spriteRenderer; // Para voltear el sprite del jugador
    private Animator animator; // Controlador de animaciones

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>(); // Obtener el sprite renderer
        animator = GetComponent<Animator>(); // Obtener el Animator
    }

    void Update()
    {
        // Capturar entrada del jugador en X y Y
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // Cambiar la dirección del sprite si se mueve a la izquierda o derecha
        if (movement.x < 0)
            spriteRenderer.flipX = true;
        else if (movement.x > 0)
            spriteRenderer.flipX = false;

        // Verificar si el jugador se está moviendo
        bool isMoving = movement.magnitude > 0;

        // Actualizar el parámetro del Animator para cambiar de Idle a Run
        animator.SetBool("isRunning", isMoving);
    }

    void FixedUpdate()
    {
        // Aplicar movimiento
        rb.linearVelocity = movement.normalized * moveSpeed;
    }
}
