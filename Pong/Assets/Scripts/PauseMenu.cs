using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public bool isGamePaused;
    public GameObject pauseMenuUI;

    ScoreManager scoreManager;
    Transform ball;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenuUI.SetActive(false);
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
        scoreManager = FindObjectOfType<ScoreManager>();
        scoreManager.OnPause += CheckPause;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (isGamePaused){
                Resume();
            }
            else{
                Pause();
            }
        }
    }

    public void CheckPause(){
        if (isGamePaused){
            Resume();
        }
        else{
            Pause();
        }
    }

    public void Resume(){
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;   
        isGamePaused = false;

    }

    public void Pause(){    
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;   
        isGamePaused = true;
    }

    public void QuitGame(){
        print("Quitting..");
        Application.Quit();
    }

    public void Reset(){
        scoreManager.player1Score = 0;
        scoreManager.player2Score = 0;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Resume();
    }
}
