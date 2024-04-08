using System;
using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        //cam = Camera.main;
        //agent = unit.GetComponent<NavMeshAgent>();  
        //agents = GetComponentsInChildren<NavMeshAgent>();
        agent = GetComponent<NavMeshAgent>(); 
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //RaycastHit hit;
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray.origin, ray.direction, out var hitInfo))
            {
                //foreach (var agent in agents)
                //{
                //    agent.destination=hitInfo.point; 
                //}
                agent.destination=hitInfo.point; 
                
            }
        }
    }
}
