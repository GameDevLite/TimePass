using System.Collections;
using UnityEngine;

public class PoolAttack : MonoBehaviour
{
    [SerializeField] private float poolDuration = 5f;
    [SerializeField] private DamageType poolDamageType = DamageType.Void;
    [SerializeField] private int damageAmount = 10;

    private bool playerInside = false;
    private PlayerHealth _playerHealth;
    private PlayerPrayer _playerPrayer;

    private void Start()
    {
        // Cache player reference
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            _playerHealth = player.GetComponent<PlayerHealth>();
            _playerPrayer = player.GetComponent<PlayerPrayer>();
        }

        // Start countdown
        StartCoroutine(PoolCountdown());
    }

    private IEnumerator PoolCountdown()
    {
        yield return new WaitForSeconds(poolDuration);

        Explode();

        Destroy(gameObject);

    }

    private void Explode()
    {
        if (_playerPrayer != null && _playerPrayer.NegatesDamage(poolDamageType) && playerInside)
        {
            Debug.Log($"Player's {poolDamageType} prayer negated the pool explosion!");
        }
        else if (_playerHealth != null)
        {
            _playerHealth.TakeDamage(damageAmount);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
        }
    }
}