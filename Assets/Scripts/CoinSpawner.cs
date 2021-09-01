using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnCoins(Vector3 startPosition)
    {
        if (Random.Range(0,2) > 0){
            MakeCoin(startPosition);
        }
        if (Random.Range(0,2) > 0){
            MakeCoin(new Vector3(startPosition.x - 1, startPosition.y, startPosition.z));
        }
        if (Random.Range(0,2) > 0){
            MakeCoin(new Vector3(startPosition.x + 1, startPosition.y, startPosition.z));
        }
    }

    private void MakeCoin(Vector3 spawnPosition)
    {
        GameObject coinGameObject = (GameObject)Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
