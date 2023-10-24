using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component.

    [Header("Attributes")]
    [SerializeField] private float moveSpeed = 2f; // Speed at which the enemy moves.

    private Transform target; // The current target (waypoint) that the enemy is moving toward.
    private int pathIndex = 0; // The index of the current waypoint in the path.

    private void Start()
    {
        // Initialize the target to the first waypoint in the path from the LevelManager.
        target = LevelManager.main.path[pathIndex];
    }

    private void Update()
    {
        // Check if the enemy is close to its current target waypoint.
        if (Vector2.Distance(target.position, transform.position) <= 0.1f)
        {
            pathIndex++; // Move to the next waypoint in the path.

            if (pathIndex == LevelManager.main.path.Length)
            {
                // If the enemy has reached the end of the path, handle its destruction, health reduction,
                // and losing conditions.
                EnemySpawner.onEnemyDestroy.Invoke(); // Invoke an event to notify enemy destruction.
                Destroy(gameObject); // Destroy the enemy.
                LevelManager.main.health -= gameObject.GetComponent<Health>().getDamageVal(); // Reduce player health.

                if (LevelManager.main.health <= 0)
                {
                    LevelManager.main.loseCondition(); // If player health is zero or less, trigger a loss condition.
                }

                return; // Exit the function.
            }
            else
            {
                target = LevelManager.main.path[pathIndex]; // Set the next waypoint as the new target.
            }
        }
    }

    private void FixedUpdate()
    {
        // Calculate the direction to the current target and set the velocity to move in that direction.
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
}