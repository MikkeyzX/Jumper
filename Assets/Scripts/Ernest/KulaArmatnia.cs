using UnityEngine;

public class KulaArmatnia : MonoBehaviour
{
    public float prędkość = 2f; // Prędkość kuli
    public float siłaOdepchnięcia = 10f; // Siła odpychania gracza

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = transform.right * prędkość; // Nadajemy ruch w poziomie
        rb.mass = 1000f; // Duża masa, aby gracz nie mógł jej przesuwać
        rb.freezeRotation = true; // Blokuje obracanie
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Lepsza detekcja kolizji
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gracz")) // Jeśli kula uderzy w gracza, odpycha go
        {
            Rigidbody2D graczRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (graczRb != null)
            {
                Vector2 kierunekOdepchnięcia = (collision.transform.position - transform.position).normalized;
                graczRb.AddForce(kierunekOdepchnięcia * siłaOdepchnięcia, ForceMode2D.Impulse);
            }
        }
        else // Jeśli kula uderzy w cokolwiek innego, znika
        {
            Destroy(gameObject);
        }
    }
}
