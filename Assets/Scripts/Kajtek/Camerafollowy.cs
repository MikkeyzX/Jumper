using UnityEngine;

public class Camerafollowy : MonoBehaviour
{
    public Transform player; 

    void Update()
    {
        if (player != null)
        {

            transform.position = new Vector3(transform.position.x, player.position.y, transform.position.z);
        }
    }
} 