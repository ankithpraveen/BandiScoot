using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public RectTransform volumeSlider;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        
        // SceneManager.UnloadSceneAsync("Game");
    }

    // Update is called once per frame
    void Update()
    {
        volumeSlider.position = new Vector3(volumeSlider.position.x, 50f, 0);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        print("Quitting..");
        Application.Quit();
    }
}
