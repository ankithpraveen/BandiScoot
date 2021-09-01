using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    // public bool isMuted = false;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;
    bool newScene = false;

    // Start is called before the first frame update
    void Awake()
    { 
        OnMenuOpen();
    }

    void OnMenuOpen(){
        // if (!PlayerPrefs.HasKey("Muted")){
        //     PlayerPrefs.SetInt("Muted", 0);
        // }
        if (!PlayerPrefs.HasKey("musicvolume"))
        {
            PlayerPrefs.SetFloat("musicvolume", 1);
        }
        Load();
        // UpdateButtonIcon();
        // AudioListener.pause = isMuted;
    }
    // Update is called once per frame
    void Update()
    {
        if (newScene == false && SceneManager.GetActiveScene().name == "Game"){
            OnMenuOpen();
            newScene = true;
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        Save();
    }

    private void Load()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("musicvolume");
        // isMuted = PlayerPrefs.GetInt("Muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicvolume", volumeSlider.value);
        // PlayerPrefs.SetInt("Muted", isMuted ? 1 : 0);
    }

    public void MutePressed()
    {
        // if (isMuted){
        //     isMuted = false;
        //     AudioListener.pause = false;
        // }
        // else{
        //     isMuted = true;
        //     AudioListener.pause = true;
        // }
        Save();
        // UpdateButtonIcon();
    }

}
