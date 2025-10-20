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
                timeText.text = "Twój czas: " + GameManager.Instance.GetFormattedTime();
        }
        else
        {
            if (timeText != null)
                timeText.text = "Twój czas: 00:00.00";
            Debug.LogWarning("GameManager.Instance jest null — albo nie istnieje, albo zosta³ usuniêty przed za³adowaniem GameOver.");
        }
    }

    // Pod³¹cz do przycisku Restart -> OnClick
    public void OnRestartPressed()
    {
        // Usuñ stary GameManager (¿eby restart by³ "czysty")
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
