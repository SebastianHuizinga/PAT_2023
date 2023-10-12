using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LevelManager : MonoBehaviour
{ 
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;

    public int money;
    public int health;

    private void Awake(){
        main = this;
    }

    private void Start() {
        money = 100;
        health = 100;
    }
     
    public void IncreaseMoney(int amount){
        money += amount;

    }

    public bool SpendMoney(int amount){
        if (amount <= money)
        {
            money -= amount;
            return true;
        }else{
            Debug.Log("Not enough money");
            return false;
        }

     



    }
}