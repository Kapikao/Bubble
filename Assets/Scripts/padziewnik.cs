using UnityEngine;

public class ChaoticMobAI : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;         // Prêdkoœæ poruszania siê
    [SerializeField] private float wanderRadius = 5f;     // Promieñ, w którym mobek mo¿e siê poruszaæ
    [SerializeField] private float directionChangeSpeed = 1f; // Jak szybko mobek zmienia kierunek (im mniejsze, tym bardziej chaotycznie)

    private Vector2 startPosition;                        // Pozycja pocz¹tkowa
    private Vector2 currentDirection;                     // Aktualny kierunek ruchu
    private Vector2 targetDirection;                      // Docelowy kierunek, do którego mobek zmierza

    void Start()
    {
        // Zapamiêtanie pozycji pocz¹tkowej
        startPosition = transform.position;

        // Ustawienie pocz¹tkowego losowego kierunku
        targetDirection = Random.insideUnitCircle.normalized;
        currentDirection = targetDirection;
    }

    void Update()
    {
        // P³ynne przejœcie do nowego kierunku
        currentDirection = Vector2.Lerp(currentDirection, targetDirection, Time.deltaTime * directionChangeSpeed).normalized;

        // Poruszanie mobka
        Move();

        // Losowa zmiana kierunku
        if (Random.value < 0.01f) // Szansa na zmianê kierunku w ka¿dej klatce (1%)
        {
            ChangeDirection();
        }
    }

    private void Move()
    {
        // Oblicz now¹ pozycjê
        Vector2 newPosition = (Vector2)transform.position + currentDirection * moveSpeed * Time.deltaTime;

        // SprawdŸ, czy mobek pozostaje w obrêbie promienia
        if (Vector2.Distance(startPosition, newPosition) <= wanderRadius)
        {
            transform.position = newPosition;
        }
        else
        {
            // Jeœli mobek wychodzi poza obszar, zmieñ kierunek na przeciwny
            targetDirection = (startPosition - (Vector2)transform.position).normalized;
        }
    }

    private void ChangeDirection()
    {
        // Wybierz nowy losowy kierunek w obrêbie jednostkowego okrêgu
        targetDirection = Random.insideUnitCircle.normalized;
    }

    private void OnDrawGizmosSelected()
    {
        // Rysuj ¿ó³ty okr¹g, który pokazuje promieñ ruchu (w edytorze Unity)
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(startPosition == Vector2.zero ? transform.position : startPosition, wanderRadius);
    }
}
