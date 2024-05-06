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
        //print("Something has entered");
        if (other.CompareTag("King"))
        {
            //print("it's the king ! ");
            StatusUpd.Instance.status = "victoire";
            //print("a");
            StatusUpd.Instance.playing = false;
            //print("b");
            StatusUpd.Instance.EndGame();
            //print("c");
           //Time.timeScale = 0;
        }
    }
}    
    
