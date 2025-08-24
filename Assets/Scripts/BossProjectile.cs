using UnityEngine;

public class BossProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 18f; // Speed of the projectile
    private DamageType _damageType = DamageType.Void;

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrayer playerPrayer = other.GetComponent<PlayerPrayer>();
            if (playerPrayer != null)
            {
                if (!playerPrayer.NegatesDamage(_damageType))
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
