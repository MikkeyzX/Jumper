using UnityEngine;

public class Armata : MonoBehaviour
{
    public GameObject kulaPrefab; // Prefab kuli armatniej
    public Transform punktStrza�u; // Punkt, z kt�rego wylatuje kula
    public float czasMi�dzyStrza�ami = 3f; // Co ile sekund armata strzela

    void Start()
    {
        InvokeRepeating("Strzel", 1f, czasMi�dzyStrza�ami); // Powtarza strza� co X sekund
    }

    void Strzel()
    {
        Instantiate(kulaPrefab, punktStrza�u.position, punktStrza�u.rotation);
    }
}
