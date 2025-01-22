using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private AudioSource footstepAudio; // Dodano AudioSource dla dźwięków kroków

    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    private float dashCooldownTimer = 0f;
    private bool isDashing = false;

    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter = 0f;

    [SerializeField] private float increasedGravity = 10f; // Zwiększona grawitacja podczas naciśnięcia 'S'
    [SerializeField] private float normalGravity = 3f; // Normalna grawitacja
    private bool isPressingS = false;

    private bool canDoubleJump = false;

    [SerializeField] private float maxSpeed = 10f; // Maksymalna prędkość gracza (całkowita prędkość wektora)

    private bool isMoving = false; // Flaga do kontrolowania dźwięków kroków

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    [System.Obsolete]
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");

            // Ruch postaci
            transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);

        horizontal = Input.GetAxisRaw("Horizontal");

        if (horizontal != 0f && IsGrounded()) // Jeśli postać się porusza i jest na ziemi
        {
            if (!isMoving) // Jeśli dźwięk kroków nie jest już odtwarzany
            {
                footstepAudio.Play(); // Odtwórz dźwięk kroków
                isMoving = true;
            }
        }
        else // Jeśli postać się nie porusza lub jest w powietrzu
        {
            footstepAudio.Stop(); // Zatrzymaj dźwięk kroków
            isMoving = false;
        }

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            canDoubleJump = true;  // Możemy wykonać podwójny skok, gdy jesteśmy na ziemi
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            coyoteTimeCounter = 0f;
            canDoubleJump = true;  // Możemy wykonać podwójny skok po pierwszym skoku
        }
        else if (Input.GetButtonDown("Jump") && !IsGrounded() && canDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower); // Podwójny skok
            canDoubleJump = false;  // Tylko jeden podwójny skok
        }

        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, rb.linearVelocity.y * 0.5f);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && dashCooldownTimer <= 0f)
        {
            StartCoroutine(Dash());
        }

        if (dashCooldownTimer > 0f)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        // Sprawdzanie, czy przytrzymujemy "S"
        isPressingS = Input.GetKey(KeyCode.S);

        Flip();

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("isWalkingBackwards", true);
        }
        else
        {
            animator.SetBool("isWalkingBackwards", false);
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
    

    [System.Obsolete]
    void FixedUpdate()
    {
        // Zmiana grawitacji w zależności od tego, czy trzymamy "S"
        if (isPressingS)
        {
            rb.gravityScale = increasedGravity;
        }
        else
        {
            rb.gravityScale = normalGravity;
        }

        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(horizontal * speed, rb.linearVelocity.y);
        }

        // Ograniczenie maksymalnej całkowitej prędkości (wektorowej)
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        // Oblicz aktualną całkowitą prędkość (moduł wektora prędkości)
        float currentSpeed = rb.linearVelocity.magnitude;

        if (currentSpeed > maxSpeed)
        {
            // Ogranicz prędkość, zachowując kierunek ruchu
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    [System.Obsolete]
    private System.Collections.IEnumerator Dash()
    {
        isDashing = true;
        dashCooldownTimer = dashCooldown;

        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        float dashDirection = isFacingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, 0f);

        yield return new WaitForSeconds(dashDuration);

        rb.gravityScale = originalGravity;
        isDashing = false;
    }
}
