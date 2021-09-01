using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSpawner : MonoBehaviour
{
    public GameObject spikePrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSpikes(Vector3 spawnPosition)
    {
        // if (Random.Range(0,4) == 0){
            MakeSpikes(spawnPosition);
        // }
    }

    private void MakeSpikes(Vector3 spawnPosition)
    {
        GameObject spikeGameObject = (GameObject)Instantiate(spikePrefab, spawnPosition, Quaternion.identity);
    }
}
