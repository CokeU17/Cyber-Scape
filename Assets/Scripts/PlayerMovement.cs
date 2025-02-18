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

    public Transform firePoint; // 🔥 Referencia al punto de disparo

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

        // Cambiar la dirección del sprite y rotar FirePoint si se mueve a la izquierda o derecha
        if (movement.x < 0)
        {
            spriteRenderer.flipX = true;
            firePoint.localRotation = Quaternion.Euler(0, 180, 0); // 🔄 Girar el FirePoint
        }
        else if (movement.x > 0)
        {
            spriteRenderer.flipX = false;
            firePoint.localRotation = Quaternion.Euler(0, 0, 0); // 🔄 Restaurar FirePoint
        }

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
