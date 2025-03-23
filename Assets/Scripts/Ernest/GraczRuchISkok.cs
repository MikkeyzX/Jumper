using UnityEngine;

public class GraczRuchISkok : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public float dashSpeed = 15f;
    public float dashTime = 0.2f;
    public float dashCooldown = 1f;

    private Rigidbody2D rb;
    private Vector2 movement;
    private bool isGrounded;
    private bool isDashing;
    private float dashTimer;
    private float dashCooldownTimer;
    private bool canDash = false; // ❌ Dash na początku zablokowany
    private float originalGravityScale; // 🟢 Do zapamiętania grawitacji

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale; // Zapisujemy normalną grawitację
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        // Skakanie
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Sprawdzanie cooldownu Dasha
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        // Dash - jeśli jest odblokowany i cooldown się skończył
        if (Input.GetKeyDown(KeyCode.LeftShift) && canDash && dashCooldownTimer <= 0)
        {
            StartDash();
        }
    }

    void FixedUpdate()
    {
        if (!isDashing)
        {
            rb.linearVelocity = new Vector2(movement.x * moveSpeed, rb.linearVelocity.y);
        }
        else
        {
            dashTimer -= Time.fixedDeltaTime;
            if (dashTimer <= 0)
            {
                StopDash();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Jeśli gracz dotknie specjalnego bloku, odblokowuje dash
        if (other.gameObject.CompareTag("DashUnlock"))
        {
            canDash = true;
            Debug.Log("Dash odblokowany! 🚀");
        }
    }

    void StartDash()
    {
        isDashing = true;
        dashTimer = dashTime;
        dashCooldownTimer = dashCooldown;

        rb.gravityScale = 0; // ❌ Wyłączamy grawitację
        rb.linearVelocity = new Vector2(movement.x != 0 ? movement.x * dashSpeed : transform.localScale.x * dashSpeed, 0);
        // Jeśli gracz stoi, dashuje w kierunku, w którym jest obrócony
    }

    void StopDash()
    {
        isDashing = false;
        rb.gravityScale = originalGravityScale; // ✅ Przywracamy normalną grawitację
    }
}
