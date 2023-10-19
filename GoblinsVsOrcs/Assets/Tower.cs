using System;
using UnityEngine;


[Serializable]
public class Tower: MonoBehaviour
{
    public string name;
    public int cost;
    public GameObject prefab;

    public Tower (string _name, int _cost, GameObject _prefab ){
        name = _name;
        cost = _cost;
        prefab = _prefab;


    }

   // public int getCost(){
       // int crost = cost;
        //return crost;



 //   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
