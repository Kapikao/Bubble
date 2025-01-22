using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f;       // Pr�dko�� pocisku
    public float damage = 20f;     // Ilo�� obra�e� zadawanych przez pocisk
    public float lifetime = 5f;    // Czas �ycia pocisku
    private Vector2 moveDirection; // Kierunek ruchu pocisku

    public void SetDirection(Vector2 direction)
    {
        moveDirection = direction.normalized; // Ustaw kierunek
    }

    private void Start()
    {
        Destroy(gameObject, lifetime); // Zniszcz pocisk po okre�lonym czasie
    }

    private void Update()
    {
        // Poruszaj pocisk w okre�lonym kierunku
        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Je�li pocisk dotknie gracza
        if (other.CompareTag("Player"))
        {
            // Pobierz skrypt PlayerHealth z gracza
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Zadaj obra�enia graczowi
            }

            Destroy(gameObject); // Zniszcz pocisk po trafieniu w gracza
        }
        else if (other.CompareTag("Obstacle"))
        {
            Destroy(gameObject); // Zniszcz pocisk po trafieniu w przeszkod�
        }
    }
}
