using UnityEngine;

public class TiltAndColor : MonoBehaviour
{
    public float tiltSpeed = 10f; // Szybko?? nachylenia
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Pobierz komponent SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Przypisz unikalny losowy kolor ka?demu obiektowi
        spriteRenderer.color = GetUniqueColor();
    }

    void Update()
    {
        // Nachylenie obiektu na podstawie ruchu myszy
        float tiltX = Input.GetAxis("Mouse X") * tiltSpeed;
        float tiltY = Input.GetAxis("Mouse Y") * tiltSpeed;

        // Zastosuj nachylenie do obiektu
        transform.rotation = Quaternion.Euler(tiltY, tiltX, 0f);
    }

    // Funkcja do generowania unikalnego losowego koloru
    Color GetUniqueColor()
    {
        // Mo?esz ustawi? odpowiedni? gam? kolorów lub losowo??, jak chcesz
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);

        return new Color(r, g, b); // Zwraca losowy kolor
    }
}
