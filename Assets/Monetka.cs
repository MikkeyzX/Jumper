using UnityEngine;

public class Monetka : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Gracz"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            if (gm != null)
            {
                gm.AddCoin();
            }

            Destroy(gameObject);
        }
    }
}
