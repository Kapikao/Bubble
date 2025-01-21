using UnityEngine;

public class SpawnPrefabsOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn; // Prefab, który chcemy zespawnowaæ (np. œwietlik)
    [SerializeField] private int spawnCount = 5;       // Liczba prefabów do zespawnowania
    [SerializeField] private float spawnRadius = 2f;   // Promieñ wokó³, w którym obiekty bêd¹ spawnowane
    [SerializeField] private bool spawnOnce = true;    // Czy ma siê spawnowaæ tylko raz?
    private bool hasSpawned = false;                  // Czy ju¿ wykonano spawn?

    private void OnTriggerEnter2D(Collider2D other)
    {
        // SprawdŸ, czy to gracz (lub inny obiekt z okreœlon¹ tag¹) wchodzi w trigger
        if (other.CompareTag("Player") && (!hasSpawned || !spawnOnce))
        {
            SpawnPrefabs();
            hasSpawned = true;
        }
    }

    private void SpawnPrefabs()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            // Losowe po³o¿enie w promieniu spawnRadius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Stwórz nowy prefab w losowym miejscu
            Instantiate(prefabToSpawn, randomPosition, Quaternion.identity);
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Rysowanie obszaru spawn w edytorze Unity
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, spawnRadius);
    }
}
