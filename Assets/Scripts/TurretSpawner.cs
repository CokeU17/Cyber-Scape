using System.Collections;
using UnityEngine;

public class TurretSpawner : MonoBehaviour
{
    public GameObject turretPrefab; // Prefab de la torreta
    public int maxTurrets = 5; // Máximo de torretas en la escena
    public float spawnInterval = 3f; // Tiempo entre cada spawn
    public Vector2 spawnAreaMin = new Vector2(-8, -8); // Límite inferior izquierdo
    public Vector2 spawnAreaMax = new Vector2(8, 8); // Límite superior derecho

    private int currentTurrets = 0;

    void Start()
    {
        StartCoroutine(SpawnTurrets());
    }

    IEnumerator SpawnTurrets()
    {
        while (currentTurrets < maxTurrets)
        {
            Vector2 spawnPosition = new Vector2(
                Random.Range(spawnAreaMin.x, spawnAreaMax.x),
                Random.Range(spawnAreaMin.y, spawnAreaMax.y)
            );

            Instantiate(turretPrefab, spawnPosition, Quaternion.identity);
            currentTurrets++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }
}
