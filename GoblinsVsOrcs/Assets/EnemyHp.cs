using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] private int hitPoints = 2; // The initial health points of the object.
    [SerializeField] private int deathValue = 50; // The value rewarded when the object is destroyed.
    [SerializeField] private int damageValue = 5; // The amount of damage the object inflicts on others.

    private bool isDead = false; // A flag to track if the object is already dead.

    // Inflict damage on the object.
    public void TakeDamage(int dmg)
    {
        hitPoints -= dmg; // Reduce health points by the specified damage.

        // Check if the object's health has reached zero and it's not already dead.
        if (hitPoints <= 0 && !isDead)
        {
            EnemySpawner.onEnemyDestroy.Invoke(); // Invoke an event to notify enemy destruction.
            LevelManager.main.IncreaseMoney(deathValue); // Increase the player's money on enemy destruction.
            LevelManager.main.totalKilled += 1; // Update the total killed count in the LevelManager.
            isDead = true; // Set the flag to indicate that the object is dead.
            Destroy(gameObject); // Destroy the object.
        }
    }

    // Get the damage value this object inflicts on others.
    public int getDamageVal()
    {
        return damageValue;
    }

    // Start is called before the first frame update. (No code in this case)
    void Start()
    {
    }

    // Update is called once per frame. (No code in this case)
    void Update()
    {
    }
}