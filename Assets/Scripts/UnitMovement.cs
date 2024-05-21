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
    public static UnitMovement Instance { get; set; }
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
    [SerializeField] LayerMask UIlayer;
    

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
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            print("1");

            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))//, ~UIlayer))
            {
                //foreach (var agent in agents)
                //{
                //    agent.destination=hitInfo.point; 
                //}
                print("2");
                if ((hitInfo.collider != null) && (hitInfo.collider.CompareTag("Enemy")))
                {
                    print("3");
                    UnitfollowEnemy(hitInfo.collider.GameObject());
                    print("4");
                }
                else
                {
                    //print("5");
                    Unitgo(hitInfo.point);
                    //print("6");
                }
                

            }
        }

        if (isUnderOrder)// && (givenDestination!=null))
        {
            if (!locationReached)
            {
                //print("oups");
                float distDestination = Vector3.Distance(this.transform.position, givenDestination);
                //print(distDestination);
                if (distDestination <= 1.1f)
                //if (agent.remainingDistance <= 2f)
                {
                    print("oupsiiii");
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
            //king = GameObject.FindWithTag("King");
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
        locationReached = false;
        enemyDead = false;
        isUnderOrder = true;
        agent.destination = cible.transform.position;
        float distEnemy = Vector3.Distance(this.transform.position, cible.transform.position);

        while (distEnemy >= 1.5)
        {
            distEnemy = Vector3.Distance(this.transform.position, cible.transform.position);
        }
        /*while (StatusUpd.Instance.playing && (StatusUpd.Instance.status != "Kingmode") && (cible is not null))
        {
            //if 
            
            float distDestination = Vector3.Distance(this.transform.position, cible.transform.position);
            //print(distDestination);
            if (distDestination >= 1.5f)
            {
                agent.destination = cible.transform.position;
            }
        }
        */
        //enemyDead = true;
        isUnderOrder = false;
        locationReached = true;
        
        
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
    
    public void SetKing(GameObject gKing)
    {
        king = gKing;

    }
    
    
}
