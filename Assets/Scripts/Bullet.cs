using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Velocidad de la bala
    public int damage = 1; // Daño que hace la bala
    public float lifetime = 3f; // Tiempo antes de destruir la bala automáticamente

    void Start()
    {
        Destroy(gameObject, lifetime); // La bala se destruye sola después de un tiempo
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); // Movimiento
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) // Si choca con un enemigo
        {
            EnemyHealth enemy = collision.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Restarle vida
            }
            Destroy(gameObject); // Destruir la bala tras el impacto
        }
    }
}
