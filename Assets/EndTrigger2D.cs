using UnityEngine;

public class EndTrigger2D : MonoBehaviour
{
    // Zmieñ tutaj na dok³adny tag u¿ywany przez Twojego gracza
    public string playerTag = "Gracz";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("[EndTrigger2D] Gracz wszed³ w Meta - koñczê grê.");
            if (GameManager.Instance != null)
            {
                GameManager.Instance.EndGame();
            }
            else
            {
                Debug.LogError("[EndTrigger2D] GameManager.Instance jest null!");
            }
        }
    }
}
