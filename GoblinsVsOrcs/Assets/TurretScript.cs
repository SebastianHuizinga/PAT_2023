using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TurretScript : MonoBehaviour
{
    // References to various components and objects.
    [Header("References")]
    [SerializeField] private Transform turretRotationPoint; // The part of the turret that rotates.
    [SerializeField] private LayerMask enemyMask; // Layer mask to detect enemies.
    [SerializeField] private GameObject bulletPrefab; // Prefab for the bullets.
    [SerializeField] private Transform firingPoint; // Point where bullets are fired from.

    // Turret attributes.
    [Header("Attributes")]
    [SerializeField] private float targetingRange = 5f; // The range within which the turret can target enemies.
    [SerializeField] private float rotationSpeed = 5f; // Rotation speed of the turret.
    [SerializeField] private float shotsPerSecond = 1f; // Rate of fire.
    [SerializeField] private int turretCost; // The cost of the turret.

    private Transform target; // The current target enemy.
    private float timeUntilShoot; // Time until the next shot can be fired.

    // Start is called before the first frame update.
    void Start()
    {
        // Initialization code can go here.
    }

    // Update is called once per frame.
    void Update()
    {
        if (target == null)
        {
            FindTarget(); // Find a new target if the current one is lost.
            return;
        }

        FaceTarget(); // Rotate the turret to face the target.

        if (!CheckTargetIsInRange())
        {
            target = null; // Reset the target if it's out of range.
        }
        else
        {
            timeUntilShoot += Time.deltaTime;

            if (timeUntilShoot >= 1f / shotsPerSecond)
            {
                Shoot(); // Fire a shot.
                timeUntilShoot = 0f;
            }

            if (LevelManager.main.hasLost == true)
            {
                Destroy(gameObject); // Destroy the turret if the game is lost.
            }
        }
    }

    // Fire a shot by instantiating a bullet.
    private void Shoot()
    {
        GameObject arrowObj = Instantiate(bulletPrefab, firingPoint.position, Quaternion.identity);
        Arrow arrowScript = arrowObj.GetComponent<Arrow>();
        arrowScript.SetTarget(target);
        LevelManager.main.totalShot += 1; // Increase the total shots fired count.
    }

    // Find the nearest enemy within the turret's range.
    private void FindTarget()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, targetingRange, (Vector2)transform.position, 0f, enemyMask);

        if (hits.Length > 0)
        {
            target = hits[0].transform;
        }
    }

    // Rotate the turret to face the target enemy.
    private void FaceTarget()
    {
        float angle = Mathf.Atan2(target.position.y - transform.position.y, target.position.x - transform.position.x) * Mathf.Rad2Deg - 90f;

        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, angle));
        turretRotationPoint.rotation = Quaternion.RotateTowards(turretRotationPoint.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Check if the target enemy is within the turret's range.
    private bool CheckTargetIsInRange()
    {
        return Vector2.Distance(target.position, transform.position) <= targetingRange;
    }

    // Return the cost of the turret.
    public int getCost()
    {
        int cost_ = turretCost;
        return cost_;
    }
}