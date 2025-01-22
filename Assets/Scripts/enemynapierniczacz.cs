using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab kulki
    public Transform firePoint;         // Punkt, z kt�rego kulka jest wystrzeliwana
    public float fireRate = 1f;         // Cz�stotliwo�� strza��w (kulka na sekund�)
    private float fireCooldown;         // Odliczanie do kolejnego strza�u
    private Transform player;           // Referencja do gracza

    private void Start()
    {
        // Znajd� gracza na podstawie tagu "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return; // Je�li gracz nie istnieje, przerwij

        // Odliczanie do kolejnego strza�u
        fireCooldown -= Time.deltaTime;

        // Je�li cooldown si� sko�czy�, przeciwnik strzela w stron� gracza
        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate; // Reset cooldownu
        }
    }

    private void Shoot()
    {
        if (player == null) return; // Je�li gracz nie istnieje, przerwij

        // Utw�rz pocisk w punkcie wystrza�u
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Wylicz kierunek w stron� gracza
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Przeka� kierunek do pocisku
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }
}
