using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAI : MonoBehaviour
{
    public float maxHealth = 100f; //HP
    public float EnemyHealth;

    public Transform[] patrolPoints; //Patrolowanie
    private int currentPatrolIndex = 0;
    public float patrolSpeed = 2f;

    public float detectionRange = 5f; // atak
    public float attackRange = 1f;
    public int damage = 3;
    public float attackCooldown = 2f;
    private float nextAttackTime = 0f;

    private Transform player; //player info
    private PlayerHealth playerHealth;

    private void Start()
    {
        EnemyHealth = maxHealth;

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Nie znaleziono gracza z tagiem 'Player'.");
        }
    }

    private void Update()
    {
            if (EnemyHealth <= 0)
            {
                Die();
            }

        if (player == null) return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            FollowPlayer();
        }
        else
        {
            Patrol();
        }

        if (distanceToPlayer <= attackRange && Time.time >= nextAttackTime)
        {
            AttackPlayer();
        }
    }

    private void Patrol()
    {
        Transform targetPoint = patrolPoints[currentPatrolIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, patrolSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.2f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, patrolSpeed * Time.deltaTime);
    }

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Przeciwnik zada³ graczowi " + damage + " obra¿eñ!");
            nextAttackTime = Time.time + attackCooldown;
        }
    }
    public void EnemyTakeDamage(float damage)
    {
        EnemyHealth -= damage;
    }
    private void Die()
    {
        Destroy(gameObject);
    }
}
