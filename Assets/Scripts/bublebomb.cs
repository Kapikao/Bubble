using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject player; // Przypisz obiekt gracza w edytorze Unity
    public float detectionRadius = 2f; // Promieñ wykrywania gracza
    public float timeToBurst = 2f; // Czas, jaki gracz musi spêdziæ w pobli¿u, aby bañka pêk³a
    public GameObject particleEffectPrefab; // Prefab efektu cz¹steczek

    private float timeInProximity = 0f; // Licznik czasu spêdzonego w pobli¿u
    private bool isPlayerNearby = false;

    void Start()
    {
        // Automatyczne przypisanie obiektu gracza na podstawie tagu
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                Debug.LogError("Nie znaleziono obiektu gracza! Upewnij siê, ¿e gracz ma tag 'Player'.");
            }
        }
    }

    void Update()
    {
        if (player == null) return; // WyjdŸ z Update, jeœli player nie zosta³ znaleziony

        // Oblicz odleg³oœæ miêdzy graczem a bañk¹
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // SprawdŸ, czy gracz jest w promieniu wykrywania
        if (distance <= detectionRadius)
        {
            if (!isPlayerNearby)
            {
                isPlayerNearby = true; // Gracz wszed³ w zasiêg
                Debug.Log("Gracz jest w pobli¿u bañki.");
            }

            // Zwiêksz licznik czasu
            timeInProximity += Time.deltaTime;

            // Jeœli czas w pobli¿u przekroczy okreœlony czas, bañka pêka
            if (timeInProximity >= timeToBurst)
            {
                BurstBubble();
            }
        }
        else
        {
            // Resetuj licznik, jeœli gracz opuœci zasiêg
            if (isPlayerNearby)
            {
                isPlayerNearby = false; // Gracz opuœci³ zasiêg
                Debug.Log("Gracz opuœci³ pobli¿e bañki.");
            }
            timeInProximity = 0f;
        }
    }

    void BurstBubble()
    {
        Debug.Log("Bañka pêk³a!");

        // Tworzenie efektu cz¹steczek, jeœli prefab jest przypisany
        if (particleEffectPrefab != null)
        {
            GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            Destroy(particleEffect, 2f); // Usuwa prefab efektu po 2 sekundach
        }

        Destroy(gameObject); // Zniszcz obiekt bañki
    }

    void OnDrawGizmosSelected()
    {
        // Rysuj promieñ wykrywania w edytorze Unity
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
