using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    [SerializeField] private float dashSpeed = 20f;
    [SerializeField] private float dashDuration = 0.2f;
    [SerializeField] private float dashCooldown = 1f;
    private float dashCooldownTimer = 0f;
    private bool isDashing = false;

    [SerializeField] private float coyoteTime = 0.2f;
    private float coyoteTimeCounter = 0f;

    // Nowe zmienne na mechanik� zwi�kszonej grawitacji
    [SerializeField] private float increasedGravity = 10f; // Zwi�kszona grawitacja podczas naci�ni�cia 'S'
    [SerializeField] private float normalGravity = 3f; // Normalna grawitacja
    private bool isPressingS = false;

    private bool canDoubleJump = false;

    [SerializeField] private float maxSpeed = 10f; // Maksymalna pr�dko�� gracza (ca�kowita pr�dko�� wektora)

    [System.Obsolete]
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
            canDoubleJump = true;  // Mo�emy wykona� podw�jny skok, gdy jeste�my na ziemi
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && coyoteTimeCounter > 0f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower);
            coyoteTimeCounter = 0f;
            canDoubleJump = true;  // Mo�emy wykona� podw�jny skok po pierwszym skoku
        }
        else if (Input.GetButtonDown("Jump") && !IsGrounded() && canDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpingPower); // Podw�jny skok
            canDoubleJump = false;  // Tylko jeden podw�jny skok
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
    }

    [System.Obsolete]
    void FixedUpdate()
    {
        // Zmiana grawitacji w zale�no�ci od tego, czy trzymamy "S"
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

        // Ograniczenie maksymalnej ca�kowitej pr�dko�ci (wektorowej)
        LimitVelocity();
    }

    private void LimitVelocity()
    {
        // Oblicz aktualn� ca�kowit� pr�dko�� (modu� wektora pr�dko�ci)
        float currentSpeed = rb.linearVelocity.magnitude;

        if (currentSpeed > maxSpeed)
        {
            // Ogranicz pr�dko��, zachowuj�c kierunek ruchu
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
