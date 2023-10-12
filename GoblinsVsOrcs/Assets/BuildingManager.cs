using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BuildingManager : MonoBehaviour
{
    public GameObject[] objects;
    public int cost;
    private GameObject pendingObj;
    private Vector3 pos;
    private RaycastHit hit;

    [SerializeField] private LayerMask layermask;
   
    

    private void Update()
    {
        if(pendingObj != null){
            pendingObj.transform.position = pos;

            if(Input.GetMouseButtonDown(0)){

                PlaceObject();
           
            }

        }
    }
    void PlaceObject(){ 
        if((LevelManager.main.money - cost) >= 0){
        LevelManager.main.money -= pendingObj.GetComponent<TurretScript>().getCost();
        LevelManager.main.moneySpent += pendingObj.GetComponent<TurretScript>().getCost();
        pendingObj = null;
         LevelManager.main.builtTowers += 1;
        
        }else{
             Debug.Log("too expensive");
        }

    }
 
    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ray, out hit, 1000, layermask)){

            pos = hit.point;

        }       
    }


    
    public void SelectObj(int index){

        pendingObj = Instantiate(objects[index], pos, transform.rotation);
        
        
       

    }

     
}
