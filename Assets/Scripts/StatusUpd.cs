using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class StatusUpd : MonoBehaviour
{
    public static StatusUpd Instance { get; set; }

    public string status = "not playing";

    public bool playing = false;

    [SerializeField] private GameObject defeatPopup;
    [SerializeField] private GameObject winPopup;
    [SerializeField] private GameObject quitPopup;
    [SerializeField] private GameObject pauseButton;
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
        status = "playing";
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
            //pauseButton.SetActive(false);
            //quitPopup.SetActive(true);
            //Time.timeScale = 0;
        }
        else
        {
            playing = true;
            status = "playing";
            pauseButton.SetActive(true);
            quitPopup.SetActive(false);
            Time.timeScale = 1;
        }


    }
    
    public void QuitButton()
    {
        status = "paused";
    }
    
    public void EndGame()
    {
        playing = false;
        if ((status == "paused") || (status == "défaite") )
        {
            quitPopup.SetActive(false);
            defeatPopup.SetActive(true);
            string stmptext = TimespentText(Timer.Instance.currentTime);
            defeatPopupTime.text = "Temps passé dans la partie : " +stmptext ;
            int unitstot = UnitSelectionManager.Instance.allUnitsList.Count;
            int unitslost = UnitSelectionManager.Instance.nbtotunitslost;
            defeatPopupUnits.text = "Nombre d'unités perdues : " + unitslost.ToString() +"/" + unitstot.ToString() ;
        }

        if (status == "victoire")
        {
            
            winPopup.SetActive(true);
            pauseButton.SetActive(false);
            string stmptext = TimespentText(Timer.Instance.currentTime);
            winPopupTime.text = "Temps passé dans la partie : " +stmptext ;
        }
    }

    public void ReturnButton()
    {
        Time.timeScale = 1;
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
