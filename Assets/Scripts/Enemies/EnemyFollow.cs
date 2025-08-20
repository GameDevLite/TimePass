using System;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    private Transform player;     // Player reference
    public float speed = 2f;      // Movement speed
    public float stopDistance = 0.5f; // How close before stopping (optional)
    
    public bool voidType = false; // Flag to check if the enemy is of void type
    public bool lightType = false; // Flag to check if the enemy is of light type
    public bool natureType = false; // Flag to check if the enemy is of nature type

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
            // switch case based on enemy type and player prayer type
            if (voidType && other.GetComponent<PlayerPrayer>().IsVoidActive)
            {
                Debug.Log("Void enemy hit the player with void prayer active.");
                // Implement logic for void enemy hitting player with void prayer active
            }
            else if (lightType && other.GetComponent<PlayerPrayer>().IsLightActive)
            {
                Debug.Log("Light enemy hit the player with light prayer active.");
                // Implement logic for light enemy hitting player with light prayer active
            }
            else if (natureType && other.GetComponent<PlayerPrayer>().IsNatureActive)
            {
                Debug.Log("Nature enemy hit the player with nature prayer active.");
                // Implement logic for nature enemy hitting player with nature prayer active
            }
            else
            {
                Debug.Log("Enemy hit the player without matching prayer type.");
                // Implement logic for enemy hitting player without matching prayer type
                other.GetComponent<PlayerHealth>().TakeDamage(1); // Example damage logic
            }
        }
    }
}