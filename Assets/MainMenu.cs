using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Ernest"); // Upewnij si�, �e scena Ernest jest poprawnie wpisana
    }
}
