using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public TextMeshProUGUI coinText;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerPos;
    public bool scoreIncreasing;
    private PlayerMovement player;
    public float highInGameScoreCount;
    public float otherScore;
    public float scoreMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        // PlayerPrefs.SetFloat("HighScore", 0);
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount = (player.transform.position.x * pointsPerPos + otherScore) * scoreMultiplier;
            if (scoreCount > highInGameScoreCount)
            {
                highInGameScoreCount = scoreCount;
            }
        }


        if (scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount;
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }

        // coinText.text = (Mathf.Round(otherScore)).ToString();
        coinText.text = "";
        scoreText.text = "Score: " + Mathf.Round(highInGameScoreCount);
        highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
    }

    public void AddOtherScore(float pointsToAdd)
    {
        otherScore += pointsToAdd;
    }
}
