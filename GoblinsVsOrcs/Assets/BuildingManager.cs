using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;  // An array of game objects that can be placed.

    public int cost;  // The cost of the currently selected object.

    private GameObject pendingObj;  // The object that is currently pending placement.
    private Vector3 pos;  // The position where the pending object will be placed.
    private RaycastHit hit;  // Information about the raycast hit.

    [SerializeField] private LayerMask layermask;  // A layer mask used for raycasting.

    private void Update()
    {
        if (pendingObj != null)
        {
            // Move the pending object to the current mouse position.
            pendingObj.transform.position = pos;

            if (Input.GetMouseButtonDown(0))
            {
                // Try to place the pending object when the left mouse button is clicked.
                PlaceObject();
            }
        }
    }

    void PlaceObject()
    {
        if ((LevelManager.main.money - cost) >= 0)
        {
            // Check if the player has enough money to place the object.
            // If so, deduct the cost from the player's money and update statistics.
            LevelManager.main.money -= cost;
            LevelManager.main.totalSpent += cost;
            LevelManager.main.totalBuilt += 1;

            // Clear the pending object since it has been placed.
            pendingObj = null;
        }
        else
        {
            Debug.Log("too expensive");  // Display a message if the object is too expensive.
        }
    }

    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000, layermask))
        {
            // Perform a raycast from the mouse pointer to the game world and store the hit position.
            pos = hit.point;
        }
    }

    public void SelectObj(int index)
    {
        // Instantiate the selected object at the current mouse position.
        pendingObj = Instantiate(objects[index], pos, transform.rotation);
        cost = pendingObj.GetComponent<TurretScript>().getCost();  // Get the cost of the selected object.
    }
}