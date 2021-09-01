using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;
    public static AudioManager instance;
    // [SerializeField] private Toggle muteToggle;

    private float[] defaultVolumes;
    // Start is called before the first frame update
    void Awake()
    {
        // muteToggle = GameObject.Find("MuteToggle");
        // foreach(Toggle toggle in toggles){
        //     if (toggle.gameObject.name = "MuteToggle"){

        //     }
        // }
        defaultVolumes = new float[sounds.Length];
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            // s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
        for (int i = 0; i < sounds.Length; i++){
            defaultVolumes[i] = sounds[i].source.volume;
        }
    }

    void Start()
    {
        PlaySound("Theme");
    }

    // Update is called once per frame
    void Update()
    {
        // if (muteToggle.isOn)
        // {
        //     Mute();
        // }
        // else
        // {
        //     Unmute();
        // }
    }

    public void PlaySound(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            return;
        }
        s.source.Play();
    }

    public void Mute()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.volume = defaultVolumes[i];
        }
    }

    public void Unmute()
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            sounds[i].source.volume = 0;
        }

    }
}
