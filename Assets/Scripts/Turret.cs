using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    [Header("Configuración de la Torreta")]
    public float rotationSpeed = 30f;  // Velocidad de rotación
    public float detectionRange = 5f;  // Rango de visión
    public LayerMask playerLayer;  // Capa del jugador para detección

    [Header("Disparo")]
    public Transform firePoint;  // Punto de disparo
    public GameObject bulletPrefab;  // Prefab de la bala
    public float fireRate = 1f;  // Tiempo entre disparos
    private float fireCooldown = 0f;  // Temporizador de disparo

    private Transform player;  // Referencia al jugador
    private bool playerDetected = false;  // Si el jugador está en rango

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;

        if (player == null)
        {
            Debug.LogError("❌ Error: No se encontró un objeto con la etiqueta 'Player' en la escena.");
        }
    }

    void Update()
    {
        if (player != null)
        {
            // Detectar al jugador dentro del rango de visión
            float distanceToPlayer = Vector2.Distance(transform.position, player.position);
            playerDetected = distanceToPlayer <= detectionRange;

            if (playerDetected)
            {
                // Rotar hacia el jugador
                RotateTowardsPlayer();

                // Disparar si el tiempo de cooldown ha terminado
                if (fireCooldown <= 0f)
                {
                    Shoot();
                    fireCooldown = fireRate;
                }
            }
        }

        // Reducir el cooldown del disparo
        fireCooldown -= Time.deltaTime;
    }

    void RotateTowardsPlayer()
    {
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = (player.position - firePoint.position).normalized;
                rb.linearVelocity = direction * 5f;  // Velocidad de la bala
                Debug.Log("🔴 Bala disparada en dirección: " + direction);
            }
        }
        else
        {
            Debug.LogError("❌ Error: BulletPrefab o FirePoint no están asignados en el Inspector.");
        }
    }
}
