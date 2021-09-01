using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnEnemy(Vector3 startPosition){
        MakeEnemy(startPosition);
    }

    public void MakeEnemy(Vector3 spawnPosition){
        GameObject enemyGameObject = (GameObject)Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
