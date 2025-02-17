using System.Collections;
using UnityEngine;

public class EscapeEnemySpawner : MonoBehaviour
{
    public GameObject escapeEnemyPrefab; // Prefab del enemigo escapista
    public int maxEnemies = 5; // Número máximo de enemigos en la escena
    public float spawnInterval = 4f; // Tiempo entre spawns

    public Vector2 spawnAreaMin = new Vector2(-8, -8); // Límite inferior izquierdo
    public Vector2 spawnAreaMax = new Vector2(8, 8); // Límite superior derecho

    private int currentEnemies = 0; // Contador de enemigos

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            if (currentEnemies < maxEnemies)
            {
                Vector2 randomPosition = new Vector2(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
                );

                Instantiate(escapeEnemyPrefab, randomPosition, Quaternion.identity);
                currentEnemies++;
            }
        }
    }
}
