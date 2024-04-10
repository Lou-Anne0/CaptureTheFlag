using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepartureZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        //print("Collission detected");
        if (other.CompareTag("King"))
        {
            StatusUpd.Instance.status = "Victoire";
            StatusUpd.Instance.playing = false;
            StatusUpd.Instance.EndGame();
           //Time.timeScale = 0;
        }
    }
}    
    
