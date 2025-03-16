using UnityEngine;

public class PlatformMoveUD : MonoBehaviour
{
    public float speed = 2f;
    public float distance = 3f;

    private Vector3 startPos;
    private int direction = 1;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.position += new Vector3(0, speed * direction * Time.deltaTime, 0);

        if (Mathf.Abs(transform.position.y - startPos.y) >= distance)
        {
            direction *= -1;
        }
    }
}
