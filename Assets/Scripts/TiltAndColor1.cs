using UnityEngine;

public class TiltAndColor1 : MonoBehaviour
{
    public float tiltSpeed = 10f; // Szybkoœæ nachylenia
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Pobierz komponent SpriteRenderer
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Przypisz unikalny losowy kolor ka¿demu obiektowi
        spriteRenderer.color = GetUniqueColor();
    }

    void Update()
    {
        // Nachylenie obiektu na podstawie ruchu myszy
        float tiltX = Input.GetAxis("Mouse X") * tiltSpeed;
        float tiltY = Input.GetAxis("Mouse Y") * tiltSpeed;

        // Obracanie obiektu w osi X i Y
        transform.Rotate(new Vector3(tiltY, -tiltX, 0) * Time.deltaTime);
    }

    // Funkcja do generowania losowego koloru z ca³ej gamy kolorów
    Color GetUniqueColor()
    {
        float r = Random.Range(0f, 1f); // Zakres od 0 do 1 dla kana³u czerwonego
        float g = Random.Range(0f, 1f); // Zakres od 0 do 1 dla kana³u zielonego
        float b = Random.Range(0f, 1f); // Zakres od 0 do 1 dla kana³u niebieskiego

        return new Color(r, g, b); // Zwraca losowy kolor w pe³nej gamie
    }
}
