using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject muzzle;
    [SerializeField] private Transform muzzlePosition; // Position where the bullet will be spawned
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullet
    
    [Header("Settings")]
    [SerializeField] private float fireDistance = 10f; // Speed of the bullet
    [SerializeField] private float fireRate = 0.5f; // Time between shots

    private Transform _player;
    private Vector2 _offset;
    
    private float _timeSinceLastShot = 0f; // Timer to track time since last shot
    private Transform _closestEnemy; // Reference to the closest enemy
    private Animator _anim;

    private void Start()
    {
        _anim = GetComponent<Animator>();
        _timeSinceLastShot = fireRate;
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = (Vector2)_player.position + _offset;
        
        FindClosestEnemy();
        AimAtEnemy();
        Shooting();
    }
    
    void FindClosestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float closestDistance = Mathf.Infinity;
        _closestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.transform.position);
            if (distance < closestDistance && distance <= fireDistance)
            {
                closestDistance = distance;
                _closestEnemy = enemy.transform;
            }
        }
    }

    void AimAtEnemy()
    {
        if (_closestEnemy != null)
        {
            Vector3 direction = _closestEnemy.position - transform.position;
            direction.Normalize();
            
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
            
            transform.position = (Vector2)_player.position + _offset;
        }
    }

    void Shooting()
    {
        if (_closestEnemy == null) return;
        
        _timeSinceLastShot += Time.deltaTime;
        if (_timeSinceLastShot >= fireRate)
        {
            Shoot();
            _timeSinceLastShot = 0f;
        }
    }

    private void Shoot()
    {
        _anim.SetTrigger("shoot");
        var muzzleGo = Instantiate(muzzle, muzzlePosition.position, transform.rotation);
        muzzleGo.transform.SetParent(transform);
        Destroy(muzzleGo, 0.05f);
        
        var projectileGo = Instantiate(bulletPrefab, muzzlePosition.position, transform.rotation);
        Destroy(projectileGo, 3);
    }


    public void SetOffset(Vector2 offset)
    {
        _offset = offset;
    }
}
