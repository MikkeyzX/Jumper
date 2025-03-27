using UnityEngine;

public class Armata : MonoBehaviour
{
    public GameObject kulaPrefab; // Prefab kuli armatniej
    public Transform punktStrza³u; // Punkt, z którego wylatuje kula
    public float czasMiêdzyStrza³ami = 3f; // Co ile sekund armata strzela

    void Start()
    {
        InvokeRepeating("Strzel", 1f, czasMiêdzyStrza³ami); // Powtarza strza³ co X sekund
    }

    void Strzel()
    {
        Instantiate(kulaPrefab, punktStrza³u.position, punktStrza³u.rotation);
    }
}
