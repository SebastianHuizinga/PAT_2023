using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] InputField nameInput; // The input field for the player's name.
    public static LevelManager main; // A reference to the main instance of the LevelManager.
    public Transform startPoint; // The starting point for enemy paths.
    public Transform[] path; // An array of waypoints defining the enemy path.
    public GameObject lossScreen; // The UI element for displaying the loss screen.
    public GameObject shopScreen; // The UI element for displaying the shop screen.
    public int money; // The player's money.
    public int health; // The player's health.
    public int totalReached = 1; // The total number of enemies that have reached the end.
    public int totalBuilt; // The total number of towers or objects built.
    public int totalShot; // The total number of shots fired.
    public int totalSpent; // The total amount of money spent.
    public int totalKilled; // The total number of enemies killed.
    public string playerName; // The player's name.
    public bool hasLost = false; // Checks to see if bloke has lost or not

    private void Awake()
    {
        main = this; // Set the LevelManager instance to the main instance of this script.
    }

    private void Start()
    {
        money = 100; // Initialize the player's money to 100.
        health = 100; // Initialize the player's health to 100.
        lossScreen.SetActive(false); // Hide the loss screen when the game starts.
    }

    public void IncreaseMoney(int amount)
    {
        money += amount; // Increase the player's money by the specified amount.
    }

    public bool SpendMoney(int amount)
    {
        if (amount <= money)
        {
            money -= amount; // Deduct money if there is enough to spend.
            return true;
        }
        else
        {
            Debug.Log("Not enough money"); // Log a message if there is not enough money to spend.
            return false;
        }
    }

    public void setName()
    {
        playerName = nameInput.text; // Set the player's name from the input field.
        nameInput.text = " "; // Clear the input field text.
    }

    public void loseCondition()
    {
        shopScreen.SetActive(false); // Hide the shop screen.
        lossScreen.SetActive(true); // Show the loss screen.
        hasLost = true; // Set the hasLost flag to true.
    }
}