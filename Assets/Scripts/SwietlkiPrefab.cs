using UnityEngine;

public class SpawnPrefabsOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject prefabToSpawn; // Prefab, kt�ry chcemy zespawnowa� (np. �wietlik)
    [SerializeField] private int spawnCount = 5;       // Liczba prefab�w do zespawnowania
    [SerializeField] private float spawnRadius = 2f;   // Promie� wok�, w kt�rym obiekty b�d� spawnowane
    [SerializeField] private bool spawnOnce = true;    // Czy ma si� spawnowa� tylko raz?
    private bool hasSpawned = false;                  // Czy ju� wykonano spawn?

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Sprawd�, czy to gracz (lub inny obiekt z okre�lon� tag�) wchodzi w trigger
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
            // Losowe po�o�enie w promieniu spawnRadius
            Vector2 randomPosition = (Vector2)transform.position + Random.insideUnitCircle * spawnRadius;

            // Stw�rz nowy prefab w losowym miejscu
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
