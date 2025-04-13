using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Ernest"); // Upewnij siê, ¿e scena Ernest jest poprawnie wpisana
    }
}
