using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public PlayerMovement player;
    private Vector3 playerStartPoint;
    public event Action OnDeath;

    private ObjectDestroyer[] oldObjectsList;

    private ScoreManager scoreManager;
    private PowerupManager powerupManager;


    // Start is called before the first frame update
    void Start()
    {
        powerupManager = FindObjectOfType<PowerupManager>();
        scoreManager = FindObjectOfType<ScoreManager>();
        playerStartPoint = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");
        FindObjectOfType<AudioManager>().PlaySound("OnDeath");
    }
    public void ResetGame()
    {
        StartCoroutine("RestartGameCo");
    }


    public IEnumerator RestartGameCo()
    {
        scoreManager.scoreIncreasing = false;
        player.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);

        oldObjectsList = FindObjectsOfType<ObjectDestroyer>();
        for (int i = 0; i < oldObjectsList.Length; i++)
        {
            Destroy(oldObjectsList[i].gameObject);
        }
        if (OnDeath != null)
        {
            OnDeath();
        }
        player.transform.position = playerStartPoint;
        player.direction = 1f;
        player.gameObject.SetActive(true);

        scoreManager.scoreCount = 0;
        scoreManager.highInGameScoreCount = 0;
        scoreManager.otherScore = 0;
        scoreManager.scoreIncreasing = true;

        powerupManager.powerupCounter = 0;
    }
}
