using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;


public class Timer : MonoBehaviour
{
    
    [SerializeField] private TMP_Text timerText = null;

    public float currentTime;

    private int maxTime = 10;
    private string temps;
    private string stminutes;
    private string stsecondes;
    private int minutes;
    private int secondes;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= maxTime * 3600f)
        {
            currentTime = maxTime * 3600f;
            timerText.color = Color.red;
        }

        SetTimerText();

    }

    private void SetTimerText()
    {
        secondes = (int) currentTime % 60;
        minutes = (int) currentTime / 60;
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
        
        temps = stminutes.ToString() + ":" + stsecondes.ToString() ;
        timerText.text = temps;
        //string plop = currentTime.ToString() ;
        //timerText.text = plop;
    }
}
