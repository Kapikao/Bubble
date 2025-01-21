using UnityEngine;

public class BubbleEnemy : MonoBehaviour
{
    [Header("Atakowanie Gracza")]
    public float attackRange = 1f; // Zasi�g ataku
    public int damage = 3; // Ilo�� obra�e� zadawanych graczowi
    public float attackCooldown = 2f; // Cooldown ataku
    private float nextAttackTime = 0f; // Czas nast�pnego ataku

    [Header("Gracz")]
    private PlayerHealth playerHealth; // Komponent zdrowia gracza

    private void AttackPlayer()
    {
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(damage);
            Debug.Log("Przeciwnik zada� graczowi " + damage + " obra�e�!");
            nextAttackTime = Time.time + attackCooldown; // Ustaw cooldown
        }
    }
}