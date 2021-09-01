using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteAudio : MonoBehaviour
{
    private Toggle muteToggle;

    // Start is called before the first frame update
    void Awake()
    {
        muteToggle = GetComponent<Toggle>();
        if (PlayerPrefs.HasKey("Muted")){
            muteToggle.isOn = PlayerPrefs.GetInt("Muted") == 1 ? true : false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (muteToggle.isOn){
            FindObjectOfType<AudioManager>().Mute();
            PlayerPrefs.SetInt("Muted",1);
        }
        else{
            FindObjectOfType<AudioManager>().Unmute();
            PlayerPrefs.SetInt("Muted",0);
        }
    }
}
