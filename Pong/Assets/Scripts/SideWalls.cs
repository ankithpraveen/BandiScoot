using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    ScoreManager score;
    AudioSource scoreSound;
    GameObject[] objs;

    // Start is called before the first frame update
    void Start()
    {
        score = FindObjectOfType<ScoreManager>();
        scoreSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        objs = GameObject.FindGameObjectsWithTag("Ball");
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            scoreSound.Play();
            score.Score(wallName);
            if (objs.Length > 1){
                Destroy(hitInfo.gameObject);
            }
            else{
                hitInfo.gameObject.SendMessage("ResetBall");
            }
        }
    }
}
