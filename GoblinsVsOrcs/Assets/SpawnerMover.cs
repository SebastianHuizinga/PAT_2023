using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMover : MonoBehaviour
{

    public Transform[] patrolPoints;
    public int nextPoint;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        nextPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position == patrolPoints[nextPoint].position){
            increaseTargetInt();
        }
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * Time.deltaTime);
    }


    void increaseTargetInt()
{   
    nextPoint++;
    if(nextPoint >= patrolPoints.Length){
     nextPoint = 0;
    }
   
}
}