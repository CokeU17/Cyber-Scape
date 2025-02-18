using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint; // Punto desde donde se disparan las balas
    public float bulletSpeed = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // Disparo con tecla "Espacio"
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar la bala en la posición y rotación de `FirePoint`
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Aplicar velocidad en la dirección del `FirePoint`
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.linearVelocity = firePoint.right * bulletSpeed; // ← Asegurar que siga la rotación del `FirePoint`
    }
}
