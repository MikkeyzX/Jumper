using UnityEngine;

public class EndTrigger2D : MonoBehaviour
{
    // Zmie� tutaj na dok�adny tag u�ywany przez Twojego gracza
    public string playerTag = "Gracz";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Debug.Log("[EndTrigger2D] Gracz wszed� w Meta - ko�cz� gr�.");
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
