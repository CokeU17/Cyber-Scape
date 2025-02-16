using UnityEngine;

public class EnemyHeavy : MonoBehaviour
{
    public float acceleration = 1f;  // Aceleración baja
    public float maxSpeed = 5f;      // Velocidad máxima alta
    private Rigidbody2D rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity += direction * acceleration * Time.fixedDeltaTime;

            // Limitar la velocidad máxima
            if (rb.linearVelocity.magnitude > maxSpeed)
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")) // Si choca con una pared
        {
            rb.linearVelocity = Vector2.zero; // Resetea la velocidad a 0
        }
    }
}
