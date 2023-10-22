using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Explodinate : MonoBehaviour
{
    
    public GameObject deathAnim;
    public Transform objPos;
    private void Update() {
       if(LevelManager.main.hasLost == true){
            
           
            
        
            // Get the position and rotation of the original object
            Vector3 position = gameObject.transform.position;
            Quaternion rotation = gameObject.transform.rotation;

                // Instantiate a clone of the object at the same position and rotation
            Instantiate(deathAnim, position, rotation);
            Destroy(gameObject);
        }
    }
}
