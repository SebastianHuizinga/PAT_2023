using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb; // Reference to the Rigidbody2D component.

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f; // Speed at which the arrow travels.
    [SerializeField] private int bulletDmg = 1; // Damage inflicted by the arrow.

    private Transform target; // Reference to the target (usually an enemy) the arrow is heading towards.

    void Start()
    {
        // Start is called before the first frame update. (No code in this case)
    }

    public void SetTarget(Transform _target)
    {
        target = _target; // Set the arrow's target to the specified Transform.
    }

    private void FixedUpdate()
    {
        if (!target) return; // If there's no target, exit the function early.

        // Calculate the direction to the target and set the velocity to move in that direction.
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed; // Set the arrow's velocity.

        // The arrow will continuously move towards its target as long as there is a target.
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // When the arrow collides with something, it deals damage to the target and then gets destroyed.
        other.gameObject.GetComponent<Health>().TakeDamage(bulletDmg); // Deal damage to the target.
        Destroy(gameObject); // Destroy the arrow object.
    }

    void OnBecameInvisible()
    {
        // If the arrow becomes invisible (e.g., goes off-screen), destroy it to save resources.
        Destroy(gameObject);
    }
}