using UnityEngine;

public class ChaoticMobAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;         // Pr�dko�� poruszania si�
    [SerializeField] private float wanderRadius = 5f;     // Promie�, w kt�rym mobek mo�e si� porusza�
    [SerializeField] private float directionChangeSpeed = 1f; // Jak szybko mobek zmienia kierunek (im mniejsze, tym bardziej chaotycznie)

    private Vector2 startPosition;                        // Pozycja pocz�tkowa
    private Vector2 currentDirection;                     // Aktualny kierunek ruchu
    private Vector2 targetDirection;                      // Docelowy kierunek, do kt�rego mobek zmierza

    void Start()
    {
        // Zapami�tanie pozycji pocz�tkowej
        startPosition = transform.position;

        // Ustawienie pocz�tkowego losowego kierunku
        targetDirection = Random.insideUnitCircle.normalized;
        currentDirection = targetDirection;
    }

    void Update()
    {
        // P�ynne przej�cie do nowego kierunku
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime * directionChangeSpeed).normalized;

        // Poruszanie mobka
        Move();

        // Losowa zmiana kierunku
        if (Random.value < 0.01f) // Szansa na zmian� kierunku w ka�dej klatce (1%)
        {
            ChangeDirection();
        }
    }

    private void Move()
    {
        // Oblicz now� pozycj�
        Vector2 newPosition = (Vector2)transform.position + currentDirection * moveSpeed * Time.deltaTime;

        // Sprawd�, czy mobek pozostaje w obr�bie promienia
        if (Vector2.Distance(startPosition, newPosition) <= wanderRadius)
        {
            transform.position = newPosition;
        }
        else
        {
            // Je�li mobek wychodzi poza obszar, zmie� kierunek na przeciwny
            targetDirection = (startPosition - (Vector2)transform.position).normalized;
        }
    }

    private void ChangeDirection()
    {
        // Wybierz nowy losowy kierunek w obr�bie jednostkowego okr�gu
        targetDirection = Random.insideUnitCircle.normalized;
    }

    private void OnDrawGizmosSelected()
    {
        // Rysuj ��ty okr�g, kt�ry pokazuje promie� ruchu (w edytorze Unity)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(startPosition == Vector2.zero ? transform.position : startPosition, wanderRadius);
    }
}
