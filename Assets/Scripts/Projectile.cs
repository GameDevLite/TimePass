using System;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 18f; // Speed of the projectile

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var enemy = other.GetComponent<EnemyHealth>();
        if (enemy != null)
        {
            Destroy(gameObject);
            enemy.TakeDamage(1); // Assuming the enemy has a TakeDamage method
        }
    }
}
