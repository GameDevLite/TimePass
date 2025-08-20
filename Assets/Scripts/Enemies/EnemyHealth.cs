using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5; // Maximum health of the enemy
    private int _currentHealth; // Current health of the enemy

    private Animator anim;
    
    [SerializeField] private Healthbar _healthbar; // Reference to the health bar UI component
    
    void Start()
    {
        anim = GetComponent<Animator>();
        _currentHealth = maxHealth; // Initialize current health to maximum health
        
        _healthbar.UpdateHealthBar(maxHealth, _currentHealth);
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage; // Reduce current health by damage amount
        _healthbar.UpdateHealthBar(maxHealth, _currentHealth);
        anim.SetTrigger("hit");
        if (_currentHealth <= 0)
        {
            Die(); // Call Die method if health is zero or below
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
