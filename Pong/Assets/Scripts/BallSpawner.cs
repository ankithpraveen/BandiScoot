using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab;
    BallControl ballControl;
    // Start is called before the first frame update
    void Start()
    {
        ballControl = FindObjectOfType<BallControl>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(){
        Vector2 spawnPosition = new Vector2(0, 0);
        GameObject newBall = (GameObject)Instantiate(ballPrefab, spawnPosition, Quaternion.Euler(Vector3.forward));
        ballControl.StartCoroutine(ballControl.WaitBeforeGo(1));
    }
}
