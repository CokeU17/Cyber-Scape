using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float rotationSpeed = 30f;
    public float fireRate = 2f;
    private bool playerDetected = false;
    private Transform player;
    private Coroutine returnToRotationCoroutine;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        StartCoroutine(RotateTurret());
    }

    IEnumerator RotateTurret()
    {
        while (true)
        {
            if (!playerDetected)
            {
                transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            }
            yield return null;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = true;
            StopCoroutine(RotateTurret());
            InvokeRepeating("Shoot", 0f, fireRate);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDetected = false;
            CancelInvoke("Shoot");

            if (returnToRotationCoroutine == null)
            {
                returnToRotationCoroutine = StartCoroutine(ReturnToRotation());
            }
        }
    }

    IEnumerator ReturnToRotation()
    {
        yield return new WaitForSeconds(2f);
        StartCoroutine(RotateTurret());
        returnToRotationCoroutine = null;
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
