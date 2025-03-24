using UnityEngine;

public class KameraPionowa : MonoBehaviour

{

    public Transform gracz; // Referencja do gracza

    public float p�ynno�� = 5f; // Jak szybko kamera pod��a za graczem



    void Update()

    {

        if (gracz != null)

        {

            // Pobieramy aktualn� pozycj� kamery

            Vector3 nowaPozycja = transform.position;



            // Ustawiamy Y na wysoko�� gracza (z interpolacj� dla p�ynnego ruchu)

            nowaPozycja.y = Mathf.Lerp(transform.position.y, gracz.position.y, p�ynno�� * Time.deltaTime);



            // Aktualizujemy pozycj� kamery

            transform.position = nowaPozycja;

        }

    }

}