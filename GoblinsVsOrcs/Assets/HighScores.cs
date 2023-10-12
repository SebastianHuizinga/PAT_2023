using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScores : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public void WriteScore()
    {
        string filePath = Application.dataPath + "/Assets/Resources/Scores.txt";

        // Text lines to write to the file
        string[] linesToWrite = {
           LevelManager.main.bulletshot.ToString(),
           LevelManager.main.enemieskilled.ToString(),
           LevelManager.main.moneySpent.ToString(),
           LevelManager.main.builtTowers.ToString()
        };

        // Open the file for writing using StreamWriter
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            // Write each line to the file
            foreach (string line in linesToWrite)
            {
                writer.WriteLine(line);
            }
        }

        Debug.Log("Lines written successfully.");
    }
}
