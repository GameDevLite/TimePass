using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrayerBar : MonoBehaviour
{
    [SerializeField] private List<Sprite> _prayerIcons; // List of prayer icons to be updated in the UI
    [SerializeField] private GameObject _prayerBarPrefab;


    private void Start()
    {
        _prayerBarPrefab.SetActive(false); // Initially hide the prayer bar
    }

    public void VoidPrayer()
    {
        _prayerBarPrefab.SetActive(true);
        _prayerBarPrefab.GetComponent<Image>().sprite = _prayerIcons[0]; // Set the sprite for the void prayer
    }
    
    public void LightPrayer()
    {
        _prayerBarPrefab.SetActive(true);
        _prayerBarPrefab.GetComponent<Image>().sprite = _prayerIcons[1]; // Set the sprite for the light prayer
    }

    public void NaturePrayer()
    {
        _prayerBarPrefab.SetActive(true);
        _prayerBarPrefab.GetComponent<Image>().sprite = _prayerIcons[2]; // Set the sprite for the nature prayer
    }

    public void DisablePrayer()
    {
        _prayerBarPrefab.SetActive(false);
    }
    
}
