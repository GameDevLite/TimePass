using System;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;     // Player reference
    public float speed = 2f;      // Movement speed
    public float stopDistance = 0.5f; // How close before stopping (optional)

    void Start()
    {
        // Find player automatically (assumes player has the tag "Player")
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return; // If player not found, do nothing

        float distance = Vector2.Distance(transform.position, player.position);

        if (distance > stopDistance)
        {
            // Move toward the player
            transform.position = Vector2.MoveTowards(
                transform.position,
                player.position,
                speed * Time.deltaTime
            );
        }

        // Flip to face player (assuming sprite faces right by default)
        Vector3 localScale = transform.localScale;
        if (player.position.x > transform.position.x)
            localScale.x = Mathf.Abs(localScale.x);   // face right
        else if (player.position.x < transform.position.x)
            localScale.x = -Mathf.Abs(localScale.x);  // face left

        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Handle collision with player (e.g., damage player, trigger game over, etc.)
            Debug.Log("Enemy collided with player!");
            // Example: You could call a method on the player to apply damage
            other.GetComponent<PlayerHealth>().TakeDamage(1);
        }
    }
}