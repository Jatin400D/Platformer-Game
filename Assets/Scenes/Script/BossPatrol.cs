using UnityEngine;

public class BossPatrol : MonoBehaviour
{

    public Transform player;
    public float detectionRange = 10f;
    public float shootRange = 7f;
    public LayerMask lineOfSightMask; // Assign obstacle layers (e.g., Ground, Walls)

    [Header("Shooting")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float fireCooldown = 2f;
    private float lastFireTime;

    [Header("Movement & Patrol")]
    public bool patrol = true;
    public Transform[] patrolPoints;
    public float moveSpeed = 2f;
    private int patrolIndex;

    [Header("Animation")]
    private Animator animator;
    private SpriteRenderer sprite;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.position);

        if (distance <= shootRange && HasLineOfSight())
        {
            FacePlayer();
            animator.SetBool("isMoving", false);
            TryShoot();
        }
        else if (patrol && patrolPoints.Length > 0)
        {
            Patrol();
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    void TryShoot()
    {
        if (Time.time - lastFireTime >= fireCooldown)
        {
            if (animator) animator.SetTrigger("Attack");

            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
            lastFireTime = Time.time;
        }
    }

    void Patrol()
    {
        Transform target = patrolPoints[patrolIndex];
        Vector2 direction = (target.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);

        animator.SetBool("isMoving", true);
        sprite.flipX = (target.position.x < transform.position.x);

        if (Vector2.Distance(transform.position, target.position) < 0.2f)
        {
            patrolIndex = (patrolIndex + 1) % patrolPoints.Length;
        }
    }

    void FacePlayer()
    {
        sprite.flipX = (player.position.x < transform.position.x);
    }

    bool HasLineOfSight()
    {
        Vector2 direction = (player.position - firePoint.position).normalized;
        float distance = Vector2.Distance(player.position, firePoint.position);

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, direction, distance, lineOfSightMask);

        if (hit.collider != null)
        {
            return hit.collider.CompareTag("Player");
        }

        return false;
    }

    void OnDrawGizmosSelected()
    {
        if (firePoint && player)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(firePoint.position, player.position);
        }
    }

}
