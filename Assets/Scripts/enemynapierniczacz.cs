using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyShooter : MonoBehaviour
{
    public GameObject projectilePrefab; // Prefab kulki
    public Transform firePoint;         // Punkt, z ktorego kulka jest wystrzeliwana
    public float fireRate = 1f;         // Czestotliwosc strzalow (kulka na sekunde)
    private float fireCooldown;         // Odliczanie do kolejnego strzalu
    private Transform player;           // Referencja do gracza

    public int enemyHP = 3;             // Punkty zycia przeciwnika
    public GameObject diesound;

    private bool isShooting = true;     // Czy przeciwnik aktualnie strzela
    private float shootingTimer = 10f;  // Licznik do przerwy w strzelaniu
    private float pauseDuration = 5f;   // Czas trwania przerwy w strzelaniu
    private float pauseTimer;           // Licznik czasu przerwy

    private void Start()
    {
        // Znajdz gracza na podstawie tagu "Player"
        player = GameObject.FindGameObjectWithTag("Player").transform;
        pauseTimer = pauseDuration; // Inicjalizacja czasu przerwy
    }

    private void Update()
    {
        if (player == null) return; // Jesli gracz nie istnieje, przerwij

        if (isShooting)
        {
            // Odliczanie do przerwy w strzelaniu
            shootingTimer -= Time.deltaTime;

            // Wykonuj strzelanie tylko wtedy, gdy odliczanie cooldownu sie skonczylo
            fireCooldown -= Time.deltaTime;
            if (fireCooldown <= 0f)
            {
                Shoot();
                fireCooldown = fireRate; // Reset cooldownu
            }

            // Przerwij strzelanie, gdy licznik osiagnie 0
            if (shootingTimer <= 0f)
            {
                isShooting = false;
                pauseTimer = pauseDuration; // Resetuj czas przerwy
            }
        }
        else
        {
            // Odliczanie czasu przerwy
            pauseTimer -= Time.deltaTime;

            // Wznow strzelanie po zakonczeniu przerwy
            if (pauseTimer <= 0f)
            {
                isShooting = true;
                shootingTimer = 10f; // Resetuj licznik do nastepnej przerwy
            }
        }
    }

    private void Shoot()
    {
        if (player == null) return; // Jesli gracz nie istnieje, przerwij

        // Utworz pocisk w punkcie wystrzalu
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);

        // Wylicz kierunek w strone gracza
        Vector2 direction = (player.position - firePoint.position).normalized;

        // Przekaz kierunek do pocisku
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.SetDirection(direction);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player touched the enemy!");

            // Zmniejsz HP przeciwnika
            enemyHP--;

            Debug.Log("Enemy HP: " + enemyHP);

            // Jesli HP przeciwnika wynosi 0 lub mniej, zniszcz przeciwnika
            if (enemyHP <= 0)
            {
                Debug.Log("Enemy destroyed!");
                Destroy(gameObject); // Zniszcz przeciwnika
                SceneManager.LoadSceneAsync(12);
                diesound.SetActive(true);
            }
        }
    }
}
