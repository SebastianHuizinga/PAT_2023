using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput; // Reference to the InputField for entering a name.
    [SerializeField] string filename; // The name of the JSON file where user entries are stored.

    List<User> entries = new List<User>(); // A list of User entries.

    private void Start()
    {
        // Read the list of User entries from the specified JSON file.
        entries = FileHandler.ReadListFromJSON<User>(filename);
    }

    // Add a new User entry to the list.
    public void AddNameToList()
    {
        // Create a new User entry with various statistics from LevelManager.
        entries.Add(new User(
            LevelManager.main.playerName,
            LevelManager.main.totalKilled,
            LevelManager.main.totalBuilt,
            LevelManager.main.totalSpent,
            LevelManager.main.totalShot,
            LevelManager.main.totalReached));

        nameInput.text = ""; // Clear the name input field.

        // Save the updated list of User entries to the JSON file.
        FileHandler.SaveToJSON<User>(entries, filename);
    }
}