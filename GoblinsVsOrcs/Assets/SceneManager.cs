using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void nextScene(){
        if(SceneManager.GetActiveScene().buildIndex >= 3){
            SceneManager.LoadScene(2);

        }
        else SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    //loads next scene

   

}
