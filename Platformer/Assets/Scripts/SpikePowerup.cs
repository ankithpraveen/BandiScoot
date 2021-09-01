using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePowerup : MonoBehaviour
{
    public bool trigger;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spikes");
        foreach (GameObject spike in spikes){
            spike.GetComponent<Collider2D>().isTrigger = trigger;
        }
    }

    // public void MakeTrigger(bool trigger){
    //     // spikePrefab.GetComponent<Collider2D>().isTrigger = trigger;

    // }
}
