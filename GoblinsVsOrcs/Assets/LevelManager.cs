using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelManager : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    public static LevelManager main;
    public Transform startPoint;
    public Transform[] path;
    public GameObject lossScreen;
    public GameObject shopScreen;
    public int money;
    public int health;
    public int totalReached = 1;
    public int totalBuilt;
    public int totalShot;
    public int totalSpent;
    public int totalKilled;
    public string playerName;
    public bool hasLost = false;
    private void Awake()
    {
        main = this;
    }

    private void Start()
    {
        money = 100;
        health = 100;
        lossScreen.SetActive(false);
    }

    public void IncreaseMoney(int amount)
    {
        money += amount;

    }

    public bool SpendMoney(int amount)
    {
        if (amount <= money)
        {
            money -= amount;
            return true;
        }
        else
        {
            Debug.Log("Not enough money");
            return false;
        }





    }

    public void setName()
    {
        playerName = nameInput.text;
        nameInput.text = " ";

    }

    public void loseCondition(){
        shopScreen.SetActive(false);
        lossScreen.SetActive(true); 
        hasLost = true;

    }

}
