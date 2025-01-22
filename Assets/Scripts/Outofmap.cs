using UnityEngine;

public class Outofmap : MonoBehaviour
{
    public int positionchose = 0; // Wyb�r pozycji
    public Vector3 customSpawnPoint = new Vector3(0f, 8.51f, 0f); // Wsp�rz�dne niestandardowe (domy�lne)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy obiekt to gracz (przyk�ad: Player tag)
        if (other.CompareTag("Player"))
        {
            if (positionchose == 0)
            {
                // Odradzanie na pozycji (0,0,0)
                other.transform.position = Vector3.zero;
            }
            else
            {
                // Odradzanie na niestandardowych wsp�rz�dnych
                other.transform.position = customSpawnPoint;
            }
        }
    }
}
