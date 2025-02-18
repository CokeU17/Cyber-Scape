using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3; // Vida m�xima del enemigo
    private int currentHealth; // Vida actual del enemigo

    void Start()
    {
        currentHealth = maxHealth; // Inicializar la vida con la vida m�xima
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Restar el da�o recibido

        Debug.Log(gameObject.name + " recibi� " + damage + " de da�o. Vida restante: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die(); // Llamar a la funci�n de muerte si la vida llega a 0
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
                TakeDamage(bullet.damage); // Aplicar da�o con la cantidad establecida en Bullet
                Destroy(collision.gameObject); // Destruir la bala despu�s del impacto
            }
        }
    }
}
