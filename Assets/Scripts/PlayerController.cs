using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float shootingRadius = 5f;
    public int maxAmmo = 10;
    public Transform gunTransform;

    private int currentAmmo;
    private Rigidbody2D rb;
    private Vector2 movement;
    private Vector2 shootDirection;
    private Transform closestEnemy;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentAmmo = maxAmmo;
    }

    void Update()
    {
        ProcessInputs();
        AimAtClosestEnemy();
    }

    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    void ProcessInputs()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");
    }

    void Move()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void AimAtClosestEnemy()
    {
        closestEnemy = FindClosestEnemy();

        if (closestEnemy != null)
        {
            shootDirection = (closestEnemy.position - transform.position).normalized;
            gunTransform.up = shootDirection;
        }
    }

    void Shoot()
    {
        if (currentAmmo > 0 && closestEnemy != null)
        {
            // Implement shooting logic, e.g., instantiate bullets, reduce ammo, etc.
            currentAmmo--;
        }
        else
        {
            // Reload logic or feedback to the player
        }
    }

    Transform FindClosestEnemy()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, shootingRadius);
        float closestDistance = Mathf.Infinity;
        Transform closestEnemy = null;

        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                float distance = Vector2.Distance(transform.position, collider.transform.position);
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestEnemy = collider.transform;
                }
            }
        }

        return closestEnemy;
    }
}