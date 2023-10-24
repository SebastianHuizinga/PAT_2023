using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerMover : MonoBehaviour
{
    public Transform[] patrolPoints; // Array of patrol points the object will move between.
    public int nextPoint; // Index of the next patrol point to move towards.
    public float speed; // Speed at which the object moves.

    // Start is called before the first frame update.
    void Start()
    {
        nextPoint = 0; // Initialize the nextPoint to the first point in the array.
    }

    // Update is called once per frame.
    void Update()
    {
        // Check if the object has reached the current patrol point.
        if (transform.position == patrolPoints[nextPoint].position)
        {
            increaseTargetInt(); // Move to the next patrol point.
        }

        // Move the object towards the current patrol point at a specified speed.
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[nextPoint].position, speed * Time.deltaTime);
    }

    // Increase the index of the next patrol point to move towards.
    void increaseTargetInt()
    {
        nextPoint++;

        // If the nextPoint goes beyond the array length, reset it to 0.
        if (nextPoint >= patrolPoints.Length)
        {
            nextPoint = 0;
        }
    }
}