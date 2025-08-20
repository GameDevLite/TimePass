using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrayer : MonoBehaviour
{
    private bool _isVoidActive = false; // Flag to check if the void is active

    public bool IsVoidActive => _isVoidActive;

    public bool IsLightActive => _isLightActive;

    public bool IsNatureActive => _isNatureActive;

    private bool _isLightActive = false; // Flag to check if the light is active
    private bool _isNatureActive = false; // Flag to check if nature is active
    
    //[SerializeField] private List<Image> prayerIcons; // List of prayer icons to be updated in the UI
    [SerializeField] private PrayerBar _prayerBar;
    
    
    public void ActivateVoid()
    {
        if (_isVoidActive)
        {
            _isVoidActive = false; // If void is already active, deactivate it
            _prayerBar.DisablePrayer(); // Update the prayer bar UI to hide the void prayer
        }
        else
        {
            _isVoidActive = true; // Set the void active flag to true
            _prayerBar.VoidPrayer(); // Update the prayer bar UI to show the void prayer
            _isLightActive = false;
            _isNatureActive = false; // Deactivate other prayers
            Debug.Log("Void activated");
        }
        
    }
    
    public void ActivateLight()
    {
        if (_isLightActive)
        {
            _isLightActive = false; // If light is already active, deactivate it
            _prayerBar.DisablePrayer(); // Update the prayer bar UI to hide the light prayer
        }
        else
        {
            _isLightActive = true; // Set the light active flag to true
            _prayerBar.LightPrayer(); // Update the prayer bar UI to show the light prayer
            _isVoidActive = false;
            _isNatureActive = false; // Deactivate other prayers
            Debug.Log("Light activated");
        }
        
    }
    
    public void ActivateNature()
    {
        if (_isNatureActive)
        {
            _isNatureActive = false; // If nature is already active, deactivate it
            _prayerBar.DisablePrayer(); // Update the prayer bar UI to hide the nature prayer
        }
        else
        {
            _isNatureActive = true; // Set the nature active flag to true
            _prayerBar.NaturePrayer(); // Update the prayer bar UI to show the nature prayer
            _isVoidActive = false;
            _isLightActive = false; // Deactivate other prayers
            Debug.Log("Nature activated");
        }
        
    }
}
