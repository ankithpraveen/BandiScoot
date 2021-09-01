using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public event Action OnPause;
    public GUISkin scoreSkin;
    public int player1Score = 0;
    public int player2Score = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Score(string wallName)
    {
        if (wallName == "rightWall")
        {
            player1Score += 1;
        }
        else if (wallName == "leftWall")
        {
            player2Score += 1;
        }
    }

    public void OnGUI()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Game")
        {
            GUI.skin = scoreSkin;
            GUI.Label(new Rect(Screen.width / 2 - 150 - 18, 20, 100, 100), "" + player1Score);
            GUI.Label(new Rect(Screen.width / 2 + 150 - 18, 20, 100, 100), "" + player2Score);
        }
    }

    public void PauseGame(){
        if (OnPause != null){
            OnPause();
        }
    }
}
