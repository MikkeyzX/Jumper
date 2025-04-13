using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Ernest");
    }

    public void QuitGame()
    {
        Debug.Log("Zamykanie gry..."); // Dzia³a tylko w edytorze jako podgl¹d
        Application.Quit(); // Dzia³a po zbudowaniu gry
    }
}
