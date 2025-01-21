using System.Collections;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject player; // Przypisz obiekt gracza w edytorze Unity
    public float detectionRadius = 2f; // Promie� wykrywania gracza
    public float timeToBurst = 2f; // Czas, jaki gracz musi sp�dzi� w pobli�u, aby ba�ka p�k�a
    public GameObject particleEffectPrefab; // Prefab efektu cz�steczek

    private float timeInProximity = 0f; // Licznik czasu sp�dzonego w pobli�u
    private bool isPlayerNearby = false;

    void Start()
    {
        // Automatyczne przypisanie obiektu gracza na podstawie tagu
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");

            if (player == null)
            {
                Debug.LogError("Nie znaleziono obiektu gracza! Upewnij si�, �e gracz ma tag 'Player'.");
            }
        }
    }

    void Update()
    {
        if (player == null) return; // Wyjd� z Update, je�li player nie zosta� znaleziony

        // Oblicz odleg�o�� mi�dzy graczem a ba�k�
        float distance = Vector3.Distance(player.transform.position, transform.position);

        // Sprawd�, czy gracz jest w promieniu wykrywania
        if (distance <= detectionRadius)
        {
            if (!isPlayerNearby)
            {
                isPlayerNearby = true; // Gracz wszed� w zasi�g
                Debug.Log("Gracz jest w pobli�u ba�ki.");
            }

            // Zwi�ksz licznik czasu
            timeInProximity += Time.deltaTime;

            // Je�li czas w pobli�u przekroczy okre�lony czas, ba�ka p�ka
            if (timeInProximity >= timeToBurst)
            {
                BurstBubble();
            }
        }
        else
        {
            // Resetuj licznik, je�li gracz opu�ci zasi�g
            if (isPlayerNearby)
            {
                isPlayerNearby = false; // Gracz opu�ci� zasi�g
                Debug.Log("Gracz opu�ci� pobli�e ba�ki.");
            }
            timeInProximity = 0f;
        }
    }

    void BurstBubble()
    {
        Debug.Log("Ba�ka p�k�a!");

        // Tworzenie efektu cz�steczek, je�li prefab jest przypisany
        if (particleEffectPrefab != null)
        {
            GameObject particleEffect = Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
            Destroy(particleEffect, 2f); // Usuwa prefab efektu po 2 sekundach
        }

        Destroy(gameObject); // Zniszcz obiekt ba�ki
    }

    void OnDrawGizmosSelected()
    {
        // Rysuj promie� wykrywania w edytorze Unity
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
