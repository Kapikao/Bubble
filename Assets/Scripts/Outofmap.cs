using UnityEngine;
using UnityEngine.SceneManagement;

public class Outofmap : MonoBehaviour
{
    public int positionchose = 0; // Wybór pozycji
    public Vector3 customSpawnPoint = new Vector3(0f, 8.51f, 0f); // Wspó³rzêdne niestandardowe (domyœlne)

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawdzamy, czy obiekt to gracz (przyk³ad: Player tag)
        if (other.CompareTag("Player"))
        {
            if (positionchose == 0)
            {
                // Odradzanie na pozycji (0,0,0)
                other.transform.position = Vector3.zero;
            }
            else if (positionchose == 5)
            {
                SceneManager.LoadSceneAsync(9);
            }
            else
            {
                // Odradzanie na niestandardowych wspó³rzêdnych
                other.transform.position = customSpawnPoint;
            }
        }
    }
}
