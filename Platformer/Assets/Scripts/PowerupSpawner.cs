using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    public GameObject powerupPrefab;
    public float powerupThreshold;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnPowerups(Vector3 startPosition){
        if (Random.Range(0, 100) < powerupThreshold){
            MakePowerups(startPosition);
        }
    }

    public void MakePowerups(Vector3 spawnPosition){
        GameObject powerupGameObject = (GameObject)Instantiate(powerupPrefab, spawnPosition, Quaternion.identity);
    }
}
