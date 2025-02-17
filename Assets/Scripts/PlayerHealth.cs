using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 3; // Vida máxima del jugador
    private int currentHP; // Vida actual del jugador

    void Start()
    {
        currentHP = maxHP; // Inicia con la vida máxima
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage; // Reduce la vida del jugador
        Debug.Log("Vida restante: " + currentHP);

        if (currentHP <= 0)
        {
            Die(); // Si la vida llega a 0, el jugador muere
        }
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto.");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia el nivel
    }
}
