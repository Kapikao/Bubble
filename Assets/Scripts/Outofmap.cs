using UnityEngine;

public class ChangePositionOnTrigger : MonoBehaviour
{
    // Ta metoda zostanie wywo?ana, gdy obiekt z tym skryptem wejdzie w obszar triggera
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy obiekt to gracz (przyk?ad: Player tag)
        if (other.CompareTag("Player"))
        {
            // Zmiana pozycji gracza na (0, 0, 0)
            other.transform.position = Vector3.zero;
        }
    }
}
