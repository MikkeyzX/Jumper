using UnityEngine;

public class KameraPionowa : MonoBehaviour

{

    public Transform gracz; // Referencja do gracza

    public float p³ynnoœæ = 5f; // Jak szybko kamera pod¹¿a za graczem



    void Update()

    {

        if (gracz != null)

        {

            // Pobieramy aktualn¹ pozycjê kamery

            Vector3 nowaPozycja = transform.position;



            // Ustawiamy Y na wysokoœæ gracza (z interpolacj¹ dla p³ynnego ruchu)

            nowaPozycja.y = Mathf.Lerp(transform.position.y, gracz.position.y, p³ynnoœæ * Time.deltaTime);



            // Aktualizujemy pozycjê kamery

            transform.position = nowaPozycja;

        }

    }

}