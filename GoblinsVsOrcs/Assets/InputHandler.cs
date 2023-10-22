using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] string filename;

    List<User> entries = new List<User>();

    private void Start()
    {
        entries = FileHandler.ReadListFromJSON<User>(filename);

    }


    public void AddNameToList()
    {
        entries.Add(new User(LevelManager.main.playerName, 
        LevelManager.main.totalKilled, 
        LevelManager.main.totalBuilt,
        LevelManager.main.totalSpent, 
        LevelManager.main.totalShot, 
        LevelManager.main.totalReached));
        nameInput.text = "";

        FileHandler.SaveToJSON<User>(entries, filename);
    }
}
