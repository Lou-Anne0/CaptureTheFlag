using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadPrefs : MonoBehaviour
{
    [Header("Settings")] 
    
    [SerializeField] private bool canUse = false;
    [SerializeField] private MenuController menuController;

    
    [Header("General volume")] 
    
    [SerializeField] private TMP_Text generalVolumeTextValue = null;
    [SerializeField] private Slider generalVolumeSlider = null;

    
    [Header("Music volume")] 
    
    [SerializeField] private TMP_Text musicVolumeTextValue = null;
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private GameObject musicJingle = null;
    
    [Header("Fx volume")] 
    
    [SerializeField] private TMP_Text fxVolumeTextValue = null;
    [SerializeField] private Slider fxVolumeSlider = null;
    [SerializeField] private GameObject FxClick = null;

    private void Awake()
    {
        if (canUse)
        {
            if (PlayerPrefs.HasKey("masterGeneralVolume"))
            {
                float localGeneralVolume = PlayerPrefs.GetFloat(("masterGeneralVolume"));
                float stepilocalGeneralVolume = localGeneralVolume * 100;
                int ilocalGeneralVolume = (int)stepilocalGeneralVolume;
                string slocalGeneralVolume = ilocalGeneralVolume.ToString();
                AudioListener.volume = localGeneralVolume;
                generalVolumeTextValue.text = slocalGeneralVolume  ;
                generalVolumeSlider.value = ilocalGeneralVolume;
            }

            else
            {
                menuController.ResetButton("General");
            }
            
            if (PlayerPrefs.HasKey("masterMusicVolume"))
            {
                float localMusicVolume = PlayerPrefs.GetFloat(("masterMusicVolume"));
                float stepilocalMusicVolume = localMusicVolume * 100;
                int ilocalMusicVolume = (int)stepilocalMusicVolume;
                string slocalMusicVolume = ilocalMusicVolume.ToString();
                AudioSource mAudioSource = musicJingle.GetComponent<AudioSource>();
                mAudioSource.volume = localMusicVolume;
                musicVolumeTextValue.text = slocalMusicVolume  ;
                musicVolumeSlider.value = ilocalMusicVolume;
            }

            else
            {
                menuController.ResetButton("Music");
            }
            
            if (PlayerPrefs.HasKey("masterFxVolume"))
            {
                float localFxVolume = PlayerPrefs.GetFloat(("masterFxVolume"));
                float stepilocalFxVolume = localFxVolume * 100;
                int ilocalFxVolume = (int)stepilocalFxVolume;
                string slocalFxVolume = ilocalFxVolume.ToString();
                AudioSource fxAudioSource = FxClick.GetComponent<AudioSource>();
                fxAudioSource.volume = localFxVolume;
                fxVolumeTextValue.text = slocalFxVolume  ;
                fxVolumeSlider.value = ilocalFxVolume;
            }

            else
            {
                menuController.ResetButton("Fx");
            }
        }
    }
}
