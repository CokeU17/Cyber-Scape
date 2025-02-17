using UnityEngine;
using System.Collections;

public class EscapeEnemy : MonoBehaviour
{
    public float fleeSpeed = 3f;
    public float fleeDuration = 3f;
    public float restDuration = 2f;
    private Transform player;
    private Rigidbody2D rb;
    private bool isFleeing = false;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2f;
    private float nextFireTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        StartCoroutine(FleeCycle());
    }

    IEnumerator FleeCycle()
    {
        while (true)
        {
            isFleeing = true;
            yield return new WaitForSeconds(fleeDuration);

            isFleeing = false;
            rb.linearVelocity = Vector2.zero;
            yield return new WaitForSeconds(restDuration);
        }
    }

    void Update()
    {
        if (isFleeing && player != null)
        {
            Vector2 fleeDirection = (transform.position - player.position).normalized;
            rb.linearVelocity = fleeDirection * fleeSpeed;
        }

        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (player != null)
        {
            Vector2 futurePosition = (Vector2)player.position + player.GetComponent<Rigidbody2D>().linearVelocity * 0.5f; // Predice su posición futura
            Vector2 direction = (futurePosition - (Vector2)transform.position).normalized;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 5f;
        }
    }
}
