using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void nextScene(){
       //checks if scenes are within build manager index range
        if(SceneManager.GetActiveScene().buildIndex + 1 >= 3){
            SceneManager.LoadScene(0);

        } //increases index of scenes in build manager 
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    //loads next scene

//closes application
   public void quitGame(){
    Application.Quit();
   }

}
