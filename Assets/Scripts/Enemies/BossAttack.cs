using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Header("Boss Projectile Spawners")]
    [SerializeField] private GameObject leftArmSpawner;
    [SerializeField] private GameObject rightArmSpawner;
    
    [Header("Boss Projectile")]
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float projectileSpeed = 10f;
    [SerializeField] private float pulseDelay = .2f;
    [SerializeField] private int projectileCount = 20;
    [SerializeField] private int pulseCount = 3;
    
    [Header("Boss Special Attack")]
    [SerializeField] private GameObject voidPoolPrefab;
    [SerializeField] private GameObject lightPoolPrefab;
    [SerializeField] private GameObject lightPoolPositionPrefab;
    [SerializeField] private GameObject voidPoolPositionPrefab;
    [SerializeField] private float poolDuration = 1f;
    
    
    [SerializeField] private bool canAttack = true;
    private Animator _animator;
    private Transform _shootingPoint;
    private Coroutine _shootingRoutine;
    private PoolAttack _poolAttack;
    
    private void Start()
    {
        _animator = GetComponent<Animator>();
        SpecialAttack();
    }
    
    public void ToggleCanAttack()
    {
        AttackRandomizer();
    }

    private void SpecialAttack()
    {
        _animator.SetTrigger("PoolAttack");
    }

    private void AttackRandomizer()
    {
        var choice = Random.Range(0, 2); // 0 = Special, 1 = Left

        switch (choice)
        {
            case 0:
                SpecialAttack();
                break;
            case 1:
                LeftAttack();
                break;
        }
    }


    public void LeftAttack()
    {
        _shootingPoint = leftArmSpawner.transform;
        
        _animator.SetTrigger("LAttack");
    }

    private IEnumerator Shoot()
    {
        for (var pulse = 0; pulse < pulseCount; pulse++)
        {
            for (var i = 0; i < projectileCount; i++)
            {
                var angle = i * (360f / projectileCount);
                var rotation = Quaternion.Euler(0, 0, angle);
                var projectile = Instantiate(projectilePrefab, _shootingPoint.position, rotation);
                var rb = projectile.GetComponent<Rigidbody2D>();
                rb.linearVelocity = rotation * Vector2.up * projectileSpeed;
                Destroy(projectile, 3f);
            }
            yield return new WaitForSeconds(pulseDelay);
        }
    }
    
    public void StartShooting()
    {
        _shootingRoutine = StartCoroutine(Shoot());
    }

    public void StopShooting()
    {
        if (_shootingRoutine != null)
        {
            StopCoroutine(_shootingRoutine);
            _shootingRoutine = null;
        }
    }
    
    public void SpawnVoidPool()
    {
        Instantiate(voidPoolPrefab, voidPoolPositionPrefab.transform.position, Quaternion.identity);
    }

    public void SpawnLightPool()
    {
        Instantiate(lightPoolPrefab, lightPoolPositionPrefab.transform.position, Quaternion.identity);
    }


}
