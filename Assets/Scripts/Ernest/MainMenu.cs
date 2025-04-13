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
        Debug.Log("Zamykanie gry..."); // Dzia�a tylko w edytorze jako podgl�d
        Application.Quit(); // Dzia�a po zbudowaniu gry
    }
}
