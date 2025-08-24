using System.Collections.Generic;
using UnityEngine;

public class GunManager : MonoBehaviour
{
    [SerializeField] private GameObject gunPrefab;

    private Transform _player;
    List<Vector2> gunPositions = new List<Vector2>();
    
    int spawnedGuns = 0;

    private void Start()
    {
        _player = GameObject.Find("Player").transform;
        
        gunPositions.Add(new Vector2(-1.2f, 1f));
        gunPositions.Add(new Vector2(1.2f, 1f));
        
        gunPositions.Add(new Vector2(-1.4f, 0.2f));
        gunPositions.Add(new Vector2(1.4f, 0.2f));
        
        gunPositions.Add(new Vector2(-1f, -0.5f));
        gunPositions.Add(new Vector2(1f, 0.5f));
        
        AddGun();
        
    }

    private void AddGun()
    {
        var pos = gunPositions[spawnedGuns];

        var newGun = Instantiate(gunPrefab, pos, Quaternion.identity);
        
        newGun.GetComponent<Gun>().SetOffset(pos);
        spawnedGuns++;
    }
}
