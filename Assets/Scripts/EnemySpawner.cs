using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemies = 10; // M�ximo de enemigos en la escena
    public float spawnInterval = 5f; // Tiempo entre cada spawn

    public Vector2 spawnAreaMin = new Vector2(-8, -8); // L�mite inferior izquierdo
    public Vector2 spawnAreaMax = new Vector2(8, 8); // L�mite superior derecho

    private int currentEnemies = 0; // Contador de enemigos en escena

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            if (currentEnemies < maxEnemies)
            {
                Vector2 spawnPosition = GetValidSpawnPosition();

                if (spawnPosition != Vector2.zero)
                {
                    Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
                    currentEnemies++;
                }
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetValidSpawnPosition()
    {
        for (int i = 0; i < 10; i++) // Intentamos encontrar un lugar v�lido hasta 10 veces
        {
            Vector2 randomPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Collider2D hit = Physics2D.OverlapCircle(randomPosition, 0.5f);

            if (hit == null) // Si no hay colisi�n con otro objeto, la posici�n es v�lida
            {
                return randomPosition;
            }
        }
        return Vector2.zero; // Si no encontr� una posici�n v�lida, regresa (0,0) y se ignora el spawn
    }
}
