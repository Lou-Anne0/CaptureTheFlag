using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using UnityEngine.InputSystem;
              // 1.599426
public class UnitMovement : MonoBehaviour
{
    // Start is called before the first frame update
    //private Camera cam;
    //private NavMeshAgent[] agents;
    //public LayerMask ground;
    //public GameObject unit = null;
    private NavMeshAgent agent;
    public bool isUnderOrder = false;
    public bool locationReached = true;
    public bool enemyDead = true;
    private Vector3 givenDestination;
    private Camera cam;
    public GameObject king;
    

    private void Start()
    {
        cam = Camera.main;
        //agent = unit.GetComponent<NavMeshAgent>();  
        //agents = GetComponentsInChildren<NavMeshAgent>();
        agent = GetComponent<NavMeshAgent>(); 
        
    }

    private void Update()
    {
        
        if ((Input.GetMouseButtonDown(0))&&(StatusUpd.Instance.playing))
        {
            //RaycastHit hit;
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                //foreach (var agent in agents)
                //{
                //    agent.destination=hitInfo.point; 
                //}
                if ((hitInfo.collider != null) && (hitInfo.collider.CompareTag("Enemy")))
                {
                    UnitfollowEnemy(hitInfo.collider.GameObject());
                }
                else
                {
                    Unitgo(hitInfo.point);
                }
                

            }
        }

        if (isUnderOrder)// && (givenDestination!=null))
        {
            if (!locationReached)
            {
                float distDestination = Vector3.Distance(this.transform.position, givenDestination);
                if (distDestination < 1f)
                {
                    isUnderOrder = false;
                    locationReached = true;
                }
            }

            if (!enemyDead)
            {
                // enemyDead = true;
            }
                
        }

        if ((StatusUpd.Instance.status == "Kingmode") && !CompareTag("King") && !isUnderOrder )
        {
            king = GameObject.FindWithTag("King");
            UnitfollowKing();
        }

    }

    private void Unitgo(Vector3 unitDest)
    {
        agent.destination = unitDest;
        givenDestination = unitDest;
        isUnderOrder = true;
        locationReached = false;
    }

    private void UnitfollowEnemy(GameObject cible)
    {
        enemyDead = false;
        isUnderOrder = true;
        while (StatusUpd.Instance.playing && (StatusUpd.Instance.status != "Kingmode") && (cible is not null))
        {
            agent.destination = cible.transform.position;
        }
        
    }
    
    private void UnitfollowKing()
    {
        //enemyDead = false;
        //isUnderOrder = true;
        while (StatusUpd.Instance.playing && (StatusUpd.Instance.status != "Kingmode") && (king is not null))
        {
            agent.destination = king.transform.position;
        }
        
    }
    
    
}
