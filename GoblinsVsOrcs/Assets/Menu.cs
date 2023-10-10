using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{

    [Header("References")]
    [SerializeField] public TextMeshProUGUI moneyUI;
    
    private void OnGUI() {
        moneyUI.text = LevelManager.main.money.ToString();
    }
    // Start is called before the first frame update
  
 
    // Update is called once per frame  
   
}