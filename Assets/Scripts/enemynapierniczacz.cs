using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab kulki
    public Transform firePoint;         // Punkt, z którego kulka jest wystrzeliwana
    public float fireRate = 1f;         // Czêstotliwoœæ strza³ów (kulka na sekundê)
    private float fireCooldown;         // Odliczanie do kolejnego strza³u
    private Transform player;           // Referencja do gracza

    private void Start()
    {
        // ZnajdŸ gracza na podstawie tagu "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (player == null) return; // Jeœli gracz nie istnieje, przerwij

        // Odliczanie do kolejnego strza³u
        fireCooldown -= Time.deltaTime;

        // Jeœli cooldown siê skoñczy³, przeciwnik strzela w stronê gracza
        if (fireCooldown <= 0f)
        {
            Shoot();
            fireCooldown = fireRate; // Reset cooldownu
        }
    }

    private void Shoot()
    {
        if (player == null) return; // Jeœli gracz nie istnieje, przerwij

        // Utwórz pocisk w punkcie wystrza³u
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Wylicz kierunek w stronê gracza
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Przeka¿ kierunek do pocisku
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }
}
