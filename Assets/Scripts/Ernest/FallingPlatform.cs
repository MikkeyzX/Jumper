using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float fallDelay = 0.5f;      // Czas zanim zniknie po wejœciu
    public float respawnDelay = 3f;     // Czas zanim znowu siê pojawi

    private Collider2D platformCollider;
    private SpriteRenderer platformRenderer;

    void Start()
    {
        platformCollider = GetComponent<Collider2D>();
        platformRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Gracz"))
        {
            Invoke("HidePlatform", fallDelay);
        }
    }

    void HidePlatform()
    {
        platformCollider.enabled = false;
        platformRenderer.enabled = false;
        Invoke("ShowPlatform", respawnDelay);
    }

    void ShowPlatform()
    {
        platformCollider.enabled = true;
        platformRenderer.enabled = true;
    }
}
