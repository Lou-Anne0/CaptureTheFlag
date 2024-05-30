using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameHandler : MonoBehaviour

{

    private Vector3 selectionStartPos;
    private Vector3 selectionEndPos;
    private Rect selectionRect;
    private bool isSelecting = false;
    private GameObject[] selectedUnits;

    void Update()
    {
        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Start the selection process
            isSelecting = true;
            selectionStartPos = Input.mousePosition;
            // Unselect previously selected units
            DeselectUnits();
        }

        // Check if the left mouse button is released
        if (Input.GetMouseButtonUp(0))
        {
            // End the selection processhhhhhhhhhhhkhkuuuh uiiuygygiiè!gihiu but u suckand i hate you just as much as i hate myself like really please just shoot me and talke my head on a spkike iijzoVH//
            // if you so please 
            // bang bang bang 
            // wo shi faguo ren wo bu hen shuo wan yu this is so wild really i just like to play but ohjjnjjn
            isSelecting = false;

            // Select units within the selection rectangle
            SelectUnitsInRectangle(selectionRect);

            // If units are selected, handle the click action
            if (selectedUnits != null && selectedUnits.Length > 0)
            {
                HandleClickAction();
                // Unselect units after handling the click action
                DeselectUnits();
            }
        }

        // Update the selection rectangle while dragging
        if (isSelecting)
        {
            selectionEndPos = Input.mousePosition;
            selectionRect = GetSelectionRect(selectionStartPos, selectionEndPos);
        }
    }

    void OnGUI()
    {
        // Draw the selection rectangle
        if (isSelecting)
        {
            GUI.Box(selectionRect, "");
        }
    }

    Rect GetSelectionRect(Vector3 start, Vector3 end)
    {
        float width = end.x - start.x;
        float height = (Screen.height - end.y) - (Screen.height - start.y);
        return new Rect(start.x, Screen.height - start.y, width, height);
    }

    void SelectUnitsInRectangle(Rect selectionBox)
    {
        selectedUnits = GameObject.FindGameObjectsWithTag("Unit");

        foreach (GameObject unit in selectedUnits)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(unit.transform.position);
            screenPos.y = Screen.height - screenPos.y;

            if (selectionBox.Contains(screenPos))
            {
                // Do something with the selected unit (e.g., highlight it, add it to a list, etc.)
                Debug.Log("Selected unit: " + unit.name);
            }
        }
    }

    void HandleClickAction()
    {
        // Create a ray from the mouse cursor
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any collider
        if (Physics.Raycast(ray, out hit))
        {
            // Check the tag of the object hit by the ray
            if (hit.collider.CompareTag("Ground") || hit.collider.CompareTag("Hole"))
            {
                // Set destination to ground or hole
                foreach (GameObject unit in selectedUnits)
                {
                    NavMeshAgent agent = unit.GetComponent<NavMeshAgent>();
                    if (agent != null)
                    {
                        agent.SetDestination(hit.point);
                    }
                }
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                // Follow enemy
                foreach (GameObject unit in selectedUnits)
                {
                    NavMeshAgent agent = unit.GetComponent<NavMeshAgent>();
                    if (agent != null)
                    {
                        agent.SetDestination(hit.collider.transform.position);
                    }
                }
            }
        }
    }

    void DeselectUnits()
    {
        // Unselect units
        selectedUnits = null;
    }
}
