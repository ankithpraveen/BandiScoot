using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public Button pauseButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "GameScene"){
            if (Time.timeScale == 0f){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame(){
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        pauseButton.gameObject.SetActive(false);
    }

    public void ResumeGame(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
    }

    public void RestartGame(){
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        pauseButton.gameObject.SetActive(true);
        FindObjectOfType<GameManager>().ResetGame();
    }

    public void QuitToMain(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
