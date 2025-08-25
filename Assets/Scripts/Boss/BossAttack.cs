using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [Header("Boss Projectile Spawners")]
    [SerializeField] private GameObject leftArmSpawner;
    [SerializeField] private GameObject rightArmSpawner;
    
    [Header("Boss Projectile")]
    [SerializeField] private GameObject projectilePrefabVoid;
    [SerializeField] private GameObject projectilePrefabLight;
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

    [SerializeField] private GameObject bossSprite;
    [SerializeField] private bool canAttack = true;
    private Animator _animator;
    private Transform _leftShootingPoint;
    private Transform _rightShootingPoint;
    private Coroutine _shootingRoutine;
    private PoolAttack _poolAttack;
    private Transform[] _shootingPoints;
    
    private void Start()
    {
        _animator = bossSprite.GetComponent<Animator>();

        if (leftArmSpawner != null)
            _leftShootingPoint = leftArmSpawner.transform;
        if (rightArmSpawner != null)
            _rightShootingPoint = rightArmSpawner.transform;

        AttackRandomizer();
    }

    
    public void ToggleCanAttack()
    {
        AttackRandomizer();
    }

    private void SpecialAttack()
    {
        _animator.SetTrigger("PoolAttack");
    }

    private void DoubleShoot()
    {
        _animator.SetTrigger("DoubleLight");
    }

    private void AttackRandomizer()
    {
        var choice = Random.Range(0, 3); // 0 = Special, 1 = Left

        switch (choice)
        {
            case 0:
                SpecialAttack();
                break;
            case 1:
                LeftAttack();
                break;
            case 2:
                DoubleShoot();
                break;
        }
    }


    public void LeftAttack()
    {
        _animator.SetTrigger("LAttack");
    }

    private IEnumerator ShootFromPoints(GameObject prefab, params Transform[] points)
    {
        for (var pulse = 0; pulse < pulseCount; pulse++)
        {
            for (var i = 0; i < projectileCount; i++)
            {
                var angle = i * (360f / projectileCount);
                var rotation = Quaternion.Euler(0, 0, angle);

                foreach (var shootingPoint in points)
                {
                    if (shootingPoint == null) continue;

                    var projectile = Instantiate(prefab, shootingPoint.position, rotation);
                    var rb = projectile.GetComponent<Rigidbody2D>();
                    rb.linearVelocity = rotation * Vector2.up * projectileSpeed;
                    Destroy(projectile, 3f);
                }
            }
            yield return new WaitForSeconds(pulseDelay);
        }
    }


    
    public void ShootLeft()
    {
        _shootingRoutine = StartCoroutine(ShootFromPoints(projectilePrefabVoid, _leftShootingPoint));
    }
    
    public void ShootRight()
    {
        _shootingRoutine = StartCoroutine(ShootFromPoints(projectilePrefabVoid, _rightShootingPoint));
    }
    
    public void ShootBoth()
    {
        _shootingRoutine = StartCoroutine(ShootFromPoints(projectilePrefabLight,_leftShootingPoint, _rightShootingPoint));
    }

    public void StopShooting()
    {
        StopCoroutine(_shootingRoutine);
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
