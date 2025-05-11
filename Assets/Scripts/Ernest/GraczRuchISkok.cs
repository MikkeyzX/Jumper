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
    private bool canDash = false;
    private float originalGravityScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravityScale = rb.gravityScale;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");

        // Skakanie
        if (Input.GetButtonDown("Jump") && isGrounded && !isDashing)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }

        // Dash
        if (dashCooldownTimer > 0)
            dashCooldownTimer -= Time.deltaTime;

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

    void StartDash()
    {
        isDashing = true;
        dashTimer = dashTime;
        dashCooldownTimer = dashCooldown;

        rb.gravityScale = 0;
        float dashDirection = movement.x != 0 ? movement.x : transform.localScale.x;
        rb.linearVelocity = new Vector2(dashDirection * dashSpeed, 0);
    }

    void StopDash()
    {
        isDashing = false;
        rb.gravityScale = originalGravityScale;
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
        if (other.CompareTag("DashUnlock"))
        {
            canDash = true;
            Debug.Log("Dash odblokowany!");
        }

        if (other.CompareTag("Finishs"))
        {
            GameTimer timer = FindObjectOfType<GameTimer>();
            if (timer != null)
                timer.StopTimer();
        }
    }
}
