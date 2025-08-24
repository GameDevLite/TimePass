using System;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;     // Player reference
    public float speed = 2f;      // Movement speed
    public float stopDistance = 0.5f; // How close before stopping (optional)

    public DamageType attackType = DamageType.Void;

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
            PlayerPrayer playerPrayer = other.GetComponent<PlayerPrayer>();
            if (playerPrayer != null)
            {
                if (!playerPrayer.NegatesDamage(attackType))
                {
                    PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
                    if (playerHealth != null)
                    {
                        playerHealth.TakeDamage(1);
                    }
                }
                else
                {
                    Debug.Log("Attack negated by prayer!");
                }
            }
        }
    }
}