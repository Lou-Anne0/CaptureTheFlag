using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance { get; set; }
    
    public List<GameObject> allUnitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();
    public int nbtotunitslost = 0;

    public LayerMask clickable;
    public AudioSource clickSound;
    private static readonly int _UNITS_LAYER = 1 << 7;
    //public LayerMask ground;
    //public GameObject groundMarker;
    
    private Camera cam;
    
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
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))                                           
        {   
            print("S");
            //RaycastHit hitInfo;                                                      
            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);                 
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);           
            //print(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable));                                                               
            //if (Physics.Raycast(ray, out hit, Mathf.Infinity, clickable))
            //print(Physics.Raycast(ray, out hit, Mathf.Infinity, clickable)); 
            Debug.DrawRay(ray.origin,ray.direction*1000,Color.red);
            if (Physics.Raycast(ray.origin, ray.direction*1000,out var hitInfo,Mathf.Infinity,clickable)) //, _UNITS_LAYER))
            {
                print("Collision");
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    print("2");
                    MultiSelect(hitInfo.collider.gameObject);
                    print("3");
                }

                else
                {
                    print("4");
                    SelectByClicking(hitInfo.collider.gameObject);
                    print("5");
                }
                
                
                //foreach (var agent in agents)                                      
                //{                                                                  
                    //agent.destination=hitInfo.point;         
                    
                //}                                                                  
            }
            else
            {
                if(!Input.GetKey(KeyCode.LeftShift))
                {
                    DeselectAll();
                } 
            }
            
        }                                                                          
    }

    private void MultiSelect(GameObject unit)
    {
        if (!unitsSelected.Contains((unit)))
        {
            clickSound.Play();
            unitsSelected.Add(unit);
            EnableUnitMovement(unit,true);
        }
        else
        {
            clickSound.Play();
            EnableUnitMovement(unit,false);
            unitsSelected.Remove(unit);
        }
    }
    
    
    private void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            EnableUnitMovement(unit, false);
        }
        unitsSelected.Clear();
    }
    
    private void SelectByClicking(GameObject unit)
    {
        DeselectAll();
        unitsSelected.Add(unit);
        EnableUnitMovement(unit, true);
    }

    private void EnableUnitMovement(GameObject unit, bool shouldMove)
    {
        unit.GetComponent<UnitMovement>().enabled = shouldMove;
    }
}
