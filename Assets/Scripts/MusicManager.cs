﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Debug.Log("dont destory on load" + name);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();   
        audioSource.volume = PlayerPrefsManager.GetMasterVolume(); 
    }

    private void OnLevelWasLoaded(int level) { 
        AudioClip thisLevelMusic = null;
        if (level < levelMusicChangeArray.Length)
        {
            thisLevelMusic = levelMusicChangeArray[level];
        }
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    public void ChangeVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
