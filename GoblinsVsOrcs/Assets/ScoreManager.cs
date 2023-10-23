using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public User user;
    public string jsonFilePath;
    void Start()
    {
        string jsonContent = File.ReadAllText(jsonFilePath);
        user = JsonUtility.FromJson<User>(jsonContent);
        Debug.Log("Name: " + user.userName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
