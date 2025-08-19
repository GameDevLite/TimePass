using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int maxHealth = 10; // Maximum health of the player
    private int _currentHealth; // Current health of the player
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHealth = maxHealth; // Initialize current health to maximum health
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage; // Reduce current health by damage amount
        Debug.Log("Player took damage: " + damage + ", Current Health: " + _currentHealth); // Log the damage taken and current health
        if (_currentHealth <= 0)
        {
            Die(); // Call Die method if health is zero or below
        }
    }

    private void Die()
    {
        Debug.Log("Player has died!"); // Log player death
        // Here you can add logic for what happens when the player dies, e.g., game over screen, respawn, etc.
        // For example, you might want to disable the player object or load a game over scene.
        //gameObject.SetActive(false); // Disable the player object
    }
}
