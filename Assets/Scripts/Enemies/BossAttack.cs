using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Header("Boss Projectile Spawners")]
    [SerializeField] private GameObject leftArmSpawner;
    [SerializeField] private GameObject rightArmSpawner;
    
    [Header("Boss Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float attackCooldown = 2f;
    
    [SerializeField] private bool canAttack = true;
    private Animator _animator;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger("LAttack");
    }
}
