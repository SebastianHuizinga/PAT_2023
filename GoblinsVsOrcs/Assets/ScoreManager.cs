using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    // References to UI Text fields and other variables.
    public User user;
    private string jsonFilePath = "C:/Users/user-pc/AppData/LocalLow/DefaultCompany/GoblinsVsOrcs/Scores.json";

    private string usernames;
    private string kills;
    private string shots;
    private string builds;
    private string spendings;
    private string level;

    public TextMeshProUGUI userNameField;
    public TextMeshProUGUI enemiesKilledField;
    public TextMeshProUGUI moneySpentField;
    public TextMeshProUGUI bulletsShotField;
    public TextMeshProUGUI towersBuitltField;
    public TextMeshProUGUI levelReachedField;

    private User[] userArray;

    void Start()
    {
        // Load user scores from the specified JSON file.
        string jsonContent = File.ReadAllText(jsonFilePath);
        List<User> userList = new List<User>(JsonHelper.FromJson<User>(jsonContent));
        userArray = userList.ToArray();

        // Sort the userArray by level reached in descending order.
        userArray = userArray.OrderByDescending(user => user.levelReached).ToArray();
        userList = userArray.ToList();

        // Display the sorted user scores.
        displayScores(userArray);
    }

    // Sort and display scores by level reached.
    public void orderByLevel()
    {
        userArray = userArray.OrderByDescending(user => user.levelReached).ToArray();
        displayScores(userArray);
    }

    // Sort and display scores by towers built.
    public void orderByBuilds()
    {
        userArray = userArray.OrderByDescending(user => user.towersBuilt).ToArray();
        displayScores(userArray);
    }

    // Sort and display scores by money spent.
    public void orderBySpendings()
    {
        userArray = userArray.OrderByDescending(user => user.moneySpent).ToArray();
        displayScores(userArray);
    }

    // Sort and display scores by arrows shot.
    public void orderByShots()
    {
        userArray = userArray.OrderByDescending(user => user.arrowsShot).ToArray();
        displayScores(userArray);
    }

    // Sort and display scores by enemies killed.
    public void orderByKills()
    {
        userArray = userArray.OrderByDescending(user => user.enemiesKilled).ToArray();
        displayScores(userArray);
    }

    // Sort and display scores by username.
    public void orderByName()
    {
        userArray = userArray.OrderBy(user => user.userName).ToArray();
        displayScores(userArray);
    }

    // Display user scores in the UI.
    public void displayScores(User[] userArray)
    {
        // Clear existing score data.
        usernames = "";
        kills = "";
        level = "";
        builds = "";
        shots = "";
        spendings = "";

        // Populate the UI text fields with user scores.
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            usernames += "#" + (i + 1) + " " + userArray[i].userName + "\n";
            userNameField.text = usernames;
        }
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            kills += userArray[i].enemiesKilled + "\n";
            enemiesKilledField.text = kills;
        }
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            shots += userArray[i].arrowsShot + "\n";
            bulletsShotField.text = shots;
        }
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            builds += userArray[i].towersBuilt + "\n";
            towersBuitltField.text = builds;
        }
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            level += userArray[i].levelReached + "\n";
            levelReachedField.text = level;
        }
        for (int i = 0; i < userArray.Length - 1; i++)
        {
            spendings += userArray[i].moneySpent + "\n";
            moneySpentField.text = spendings;
        }
    }
}
