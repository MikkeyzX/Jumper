using UnityEngine;

public class Armata : MonoBehaviour
{
    public GameObject kulaPrefab; // Prefab kuli armatniej
    public Transform punktStrzału; // Punkt, z którego wylatuje kula
    public float czasMiędzyStrzałami = 3f; // Co ile sekund armata strzela

    void Start()
    {
        InvokeRepeating("Strzel", 1f, czasMiędzyStrzałami); // Powtarza strzał co X sekund
    }

    void Strzel()
    {
        Instantiate(kulaPrefab, punktStrzału.position, punktStrzału.rotation);
    }
}
