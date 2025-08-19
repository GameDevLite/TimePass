using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    
    [SerializeField] private Image _healthbarImage; // Reference to the health bar image
    
    public void UpdateHealthBar(float MaxHealth, float CurrentHealth)
    {
        _healthbarImage.fillAmount = CurrentHealth / MaxHealth;
    }
}
