using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int maxEnemies = 10;
    public float spawnInterval = 5f;
    public Vector2 spawnAreaMin = new Vector2(-8, -8);
    public Vector2 spawnAreaMax = new Vector2(8, 8);

    private int currentEnemies = 0;

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
                Vector2 spawnPosition = new Vector2(
                    Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                    Random.Range(spawnAreaMin.y, spawnAreaMax.y)
                );

                int randomIndex = Random.Range(0, enemyPrefabs.Length);
                Instantiate(enemyPrefabs[randomIndex], spawnPosition, Quaternion.identity);
                currentEnemies++;
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
