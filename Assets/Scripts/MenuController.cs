using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;

public class MenuController : MonoBehaviour
{
    [Header("General Sound Settings")] 
    
    [SerializeField] private TMP_Text generalVolumeTextValue = null;
    [SerializeField] private Slider generalVolumeSlider = null;
    [SerializeField] private GameObject SGcomfirmationPrompt = null;
    [SerializeField] private int defaultgVolume = 25;
    
    [Header("Music Sound Settings")] 
    
    [SerializeField] private TMP_Text musicVolumeTextValue = null;
    [SerializeField] private Slider musicVolumeSlider = null;
    [SerializeField] private int defaultmVolume = 25;
    [SerializeField] private GameObject musicJingle = null;
    
    [Header("Fx Sound Settings")] 
    
    [SerializeField] private TMP_Text fxVolumeTextValue = null;
    [SerializeField] private Slider fxVolumeSlider = null;
    [SerializeField] private int defaultfxVolume = 100;
    [SerializeField] private GameObject FxClick = null;
    // Penser à ajouter les autres effets si besoin
    public void PlayButton(String ArenaChosen)
    {
        SceneManager.LoadScene(ArenaChosen);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SetGeneralVolume()
    {
        float vol = generalVolumeSlider.value / 100;
        AudioListener.volume = vol;
        //string gvolume = generalVolumeSlider.value.ToString("D");
        //string gvolume = "44";
        //print(generalVolumeSlider.value);
        //print(generalVolumeSlider.value.GetType());
        string gvolume = generalVolumeSlider.value.ToString();
        //print("caca");
        //print(caca);
        //print("type caca");
        //print(caca.GetType());
        generalVolumeTextValue.text = gvolume ;
    }
    

    public void GeneralVolumeApply()
    {
        PlayerPrefs.SetFloat("masterGeneralVolume",AudioListener.volume);
        StartCoroutine(SGConfirmationBox());
    }
    
    public void SetMusicVolume()
    {
        float mvol = musicVolumeSlider.value / 100;
        AudioSource mAudioSource = musicJingle.GetComponent<AudioSource>();
        mAudioSource.volume = mvol;
        string mvolume = musicVolumeSlider.value.ToString();
        musicVolumeTextValue.text = mvolume ;
    }
    
    public void MusicVolumeApply()
    {
        AudioSource mAudioSource = musicJingle.GetComponent<AudioSource>();
        float mlevel = mAudioSource.volume;
        PlayerPrefs.SetFloat("masterMusicVolume",mlevel);
        //Volume volume = gameObject.GetComponent<Volume>();
        StartCoroutine(SGConfirmationBox());
    }
    
    
    public void SetFxVolume()
    {
        float fxvol = fxVolumeSlider.value / 100;
        AudioSource fxAudioSource = FxClick.GetComponent<AudioSource>();
        fxAudioSource.volume = fxvol;
        string fxvolume = fxVolumeSlider.value.ToString();
        fxVolumeTextValue.text = fxvolume ;
    }
    
    public void FxVolumeApply()
    {
        AudioSource fxAudioSource = FxClick.GetComponent<AudioSource>();
        float fxlevel = fxAudioSource.volume;
        PlayerPrefs.SetFloat("masterFxVolume", fxlevel);
        StartCoroutine(SGConfirmationBox());
    }
    
   
    
    
    public void ResetButton(string MenuType)
    {
        if (MenuType == "General")
        {
            float fdefaultgVolume = defaultgVolume / 100;
            string sdefaultgVolume = defaultgVolume.ToString();
            AudioListener.volume = fdefaultgVolume;
            generalVolumeTextValue.text = sdefaultgVolume  ;
            generalVolumeSlider.value = defaultgVolume;
            GeneralVolumeApply();
        }
        
        if (MenuType == "Music")
        {
            float fdefaultmVolume = defaultmVolume / 100;
            string sdefaultmVolume = defaultmVolume.ToString();
            AudioSource mAudioSource = musicJingle.GetComponent<AudioSource>();
            mAudioSource.volume = fdefaultmVolume;
            musicVolumeTextValue.text = sdefaultmVolume  ;
            musicVolumeSlider.value = defaultmVolume;
            MusicVolumeApply();
        }
        
        if (MenuType == "Fx")
        {
            float fdefaultfxVolume = defaultfxVolume / 100;
            string sdefaultfxVolume = defaultfxVolume.ToString();
            AudioSource fxAudioSource = FxClick.GetComponent<AudioSource>();
            fxAudioSource.volume = fdefaultfxVolume;
            fxVolumeTextValue.text = sdefaultfxVolume  ;
            fxVolumeSlider.value = defaultfxVolume;
            MusicVolumeApply();
        }
    }

    public IEnumerator SGConfirmationBox()
    {
        SGcomfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(2);
        SGcomfirmationPrompt.SetActive(false);
    }

    
}
