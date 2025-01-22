using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public GameObject deatheffect;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth / maxHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth / maxHealth);
    }

    

    void Update()
    {
        
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    
    private void Die()
    {
        Debug.Log("Gracz umarł! Resetowanie sceny...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        deatheffect.SetActive(true);
        SceneManager.LoadSceneAsync(3);

    }
}