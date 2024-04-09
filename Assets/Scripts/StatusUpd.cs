using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StatusUpd : MonoBehaviour
{
    public static StatusUpd Instance { get; set; }

    public string status = "not playing";

    public bool playing = false;

    [SerializeField] private GameObject defeatPopup;
    [SerializeField] private GameObject winPopup;
    [SerializeField] private TMP_Text defeatPopupTime;
    [SerializeField] private TMP_Text winPopupTime;
    [SerializeField] private TMP_Text defeatPopupUnits;
        // victoire défaite pause play 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        playing = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PauseGame(bool st)
    {
        if (st)
        {
            playing = false;
            status = "paused";
        }
        else
        {
            playing = true;
            status = "playing";
        }


    }
    
    public void QuitButton()
    {
        status = "défaite";
    }
    
    public void EndGame()
    {
        playing = false;
        if ((status == "paused") || (status == "défaite") )
        {
            defeatPopup.SetActive(true);
            string stmptext = TimespentText(Timer.Instance.currentTime);
            defeatPopupTime.text = "Temps passé dans la partie : " +stmptext ;
            //defeatPopupUnits.text = "Nombre d'unités perdues : " +stmptext ;
        }

        if (status == "victoire")
        {
            winPopup.SetActive(true);
            string stmptext = TimespentText(Timer.Instance.currentTime);
            winPopupTime.text = "Temps passé dans la partie : " +stmptext ;
        }
    }

    public void ReturnButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    private static string TimespentText(float currentTime)
    {
        int secondes = (int) currentTime % 60;
        int minutes = (int) currentTime / 60;
        string stminutes;
        string stsecondes;
        
        if (minutes < 10)
        {
            stminutes = "0" + minutes.ToString();
        }
        else
        {
            stminutes = minutes.ToString();
        }
        if (secondes < 10)
        {
            stsecondes = "0" + secondes.ToString();
        }
        else
        {
            stsecondes = secondes.ToString();
        }  
        
        string temps = stminutes.ToString() + "m" + stsecondes.ToString()+ "s" ;

        return temps;
    }
    
}
