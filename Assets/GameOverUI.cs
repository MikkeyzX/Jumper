using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    public TextMeshProUGUI titleText;   // przypnij w inspectorze
    public TextMeshProUGUI timeText;    // przypnij w inspectorze
    public string restartSceneName = "Ernest"; // nazwa sceny do restartu

    void Start()
    {
        if (titleText != null) titleText.text = "GAME OVER";

        if (GameManager.Instance != null)
        {
            if (timeText != null)
                timeText.text = "Tw�j czas: " + GameManager.Instance.GetFormattedTime();
        }
        else
        {
            if (timeText != null)
                timeText.text = "Tw�j czas: 00:00.00";
            Debug.LogWarning("GameManager.Instance jest null � albo nie istnieje, albo zosta� usuni�ty przed za�adowaniem GameOver.");
        }
    }

    // Pod��cz do przycisku Restart -> OnClick
    public void OnRestartPressed()
    {
        // Usu� stary GameManager (�eby restart by� "czysty")
        if (GameManager.Instance != null)
        {
            Destroy(GameManager.Instance.gameObject);
        }
        SceneManager.LoadScene(restartSceneName);
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
