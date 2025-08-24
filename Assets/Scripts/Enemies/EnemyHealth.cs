using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int _currentHealth;

    private Animator _anim;
    
    [SerializeField] private Healthbar _healthbar;
    
    void Start()
    {
        _anim = GetComponent<Animator>();
        _currentHealth = maxHealth;
        
        _healthbar.UpdateHealthBar(maxHealth, _currentHealth);
    }
    
    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        _healthbar.UpdateHealthBar(maxHealth, _currentHealth);
        //anim.SetTrigger("hit");
        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
