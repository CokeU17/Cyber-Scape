using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vida máxima del enemigo
    private int currentHealth; // Vida actual del enemigo

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida con la vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restar el daño recibido

        Debug.Log(gameObject.name + " recibió " + damage + " de daño. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Llamar a la función de muerte si la vida llega a 0
        }
    }

    void Die()
    {
        Debug.Log(gameObject.name + " ha sido destruido.");
        Destroy(gameObject); // Eliminar al enemigo
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Bullet bullet = collision.gameObject.GetComponent<Bullet>(); // Obtener el componente Bullet
            if (bullet != null)
            {
                TakeDamage(bullet.damage); // Aplicar daño con la cantidad establecida en Bullet
                Destroy(collision.gameObject); // Destruir la bala después del impacto
            }
        }
    }
}
