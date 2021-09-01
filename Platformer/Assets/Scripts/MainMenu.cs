using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Toggle tutToggle;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("tutOn")){
            tutToggle.isOn = PlayerPrefs.GetInt("tutOn") == 1 ? true : false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape)){
            QuitGame();
        }
    }

    public void PlayGame()
    {
        if (tutToggle.isOn)
        {
            SceneManager.LoadScene("Tutorial");
            PlayerPrefs.SetInt("tutOn",1);
        }
        else
        {
            SceneManager.LoadScene("GameScene");
            PlayerPrefs.SetInt("tutOn",0);
        }

    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
