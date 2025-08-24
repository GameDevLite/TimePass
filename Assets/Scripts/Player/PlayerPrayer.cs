using UnityEngine;

public class PlayerPrayer : MonoBehaviour
{
    [SerializeField] private PrayerBar _prayerBar;
    
    public void ActivateVoidPrayer()   => ActivatePrayer(DamageType.Void);
    public void ActivateLightPrayer()  => ActivatePrayer(DamageType.Light);
    public void ActivateNaturePrayer() => ActivatePrayer(DamageType.Nature);


    public DamageType ActivePrayer { get; private set; } = DamageType.None;

    public void ActivatePrayer(DamageType prayerType)
    {
        // If the same prayer is already active, deactivate it
        if (ActivePrayer == prayerType)
        {
            ActivePrayer = DamageType.None;
            _prayerBar.DisablePrayer();
            return;
        }

        // Set new active prayer
        ActivePrayer = prayerType;

        // Update UI depending on type
        switch (prayerType)
        {
            case DamageType.Void:
                _prayerBar.VoidPrayer();
                break;
            case DamageType.Light:
                _prayerBar.LightPrayer();
                break;
            case DamageType.Nature:
                _prayerBar.NaturePrayer();
                break;
        }
    }

    // Helper function to check if a damage type is negated
    public bool NegatesDamage(DamageType damageType)
    {
        return ActivePrayer == damageType;
    }
}