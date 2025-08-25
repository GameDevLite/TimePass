using UnityEngine;

public class BossAnimationHelper : MonoBehaviour
{
    private BossAttack _bossAttack;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _bossAttack = GetComponentInParent<BossAttack>();
    }
    
    public void TriggerDoubleShoot()
    {
        _bossAttack.ShootBoth();
    }
    
    public void TriggerLeftShoot()
    {
        _bossAttack.ShootLeft();
    }
    
    public void TriggerRightShoot()
    {
        _bossAttack.ShootRight();
    }

    public void TriggerCanAttack()
    {
        _bossAttack.ToggleCanAttack();
    }
    
    public void TriggerStopShooting()
    {
        _bossAttack.StopShooting();
    }
}
