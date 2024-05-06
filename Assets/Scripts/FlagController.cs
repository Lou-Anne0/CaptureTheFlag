using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FlagController : MonoBehaviour
{
    private Transform[] goOnUnit;
    private GameObject flagOnUnit;
    private GameObject crownHolder;
    private GameObject crown;
    private Transform[] goWcrown;
    [SerializeField] private GameObject PressText;

    private void OnTriggerStay(Collider other)
    {
        //print("Collission detected");
        if (other.CompareTag("Unit")) 
        {
            PressText.SetActive(true);
            
            if (Input.GetKey(KeyCode.F))
            {
                PressText.SetActive(false);
                this.gameObject.SetActive(false);
                StatusUpd.Instance.status = "Kingmode";

                GameObject unit = other.gameObject;
                //print("1");
                //goOnUnit = unit.GetComponents<Tag>()
                //goOnUnit =GameObject.FindGameObjectsWithTag("Flagwunit");
                //goWcrown = GameObject.FindGameObjectsWithTag("HealthBarCanvasTag");


                //goOnUnit = unit.GetComponents<Transform>();
                //print("2");
                //print(goOnUnit==null);
                
                goOnUnit = unit.GetComponentsInChildren<Transform>(true);
                //print("2bis");
                //print(goOnUnit.Length);

                unit.tag = "King";
                
                //UnitMovement.

                //UnitMovement.Instance.SetKing(unit); 
                
                foreach (Transform numy in goOnUnit)
                {
                    //print(numy.gameObject.name);
                    if (numy.gameObject.name == "Flagwunit")
                    {
                        flagOnUnit = numy.gameObject;
                        //print("3");
                    }

                //}
                //foreach (GameObject numy in goOnUnit)
                //{
                    if (numy.gameObject.name == "HealthBarCanvas")
                    {
                        crownHolder = numy.gameObject;
                        //print("4");
                    }

                }
                
                

                flagOnUnit.SetActive(true);
                //print("5");

                goWcrown = crownHolder.GetComponentsInChildren<Transform>(true);
                //print("6");

                foreach (Transform numy in goWcrown)
                {
                    if (numy.gameObject.name == "Crown")
                    {
                        crown = numy.gameObject;
                        //print("7");
                    }
                }
                
                crown.SetActive(true);
                //print("8");
            }
        }
    }
}