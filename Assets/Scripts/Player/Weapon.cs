using UnityEngine;

public class Weapon : MonoBehaviour
{
    private int _damage = 2;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Assuming the enemy has an EnemyHealth component
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(_damage);
            }
        }
    }
    
}
