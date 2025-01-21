using UnityEngine;

public class BubbleEnemy : MonoBehaviour
{
    [Header("Atakowanie Gracza")]
    public float attackRange = 1f; // Zasiêg ataku
    public int damage = 3; // Iloœæ obra¿eñ zadawanych graczowi
    public float attackCooldown = 2f; // Cooldown ataku
    private float nextAttackTime = 0f; // Czas nastêpnego ataku

    [Header("Gracz")]
    private PlayerHealth playerHealth; // Komponent zdrowia gracza

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Przeciwnik zada³ graczowi " + damage + " obra¿eñ!");
            nextAttackTime = Time.time + attackCooldown; // Ustaw cooldown
        }
    }
}