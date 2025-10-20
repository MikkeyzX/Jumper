using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public GameObject scoreObject;
    public int iScore = 0;
    public float elapsedTime { get; private set; } = 0f;
    public bool isRunning { get; private set; } = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Update()
    {
        if (!isRunning) return;
        elapsedTime += Time.deltaTime;
    }

    public void AddScore()
    {
        iScore++;
        scoreObject.GetComponent<TextMeshProUGUI>().SetText(iScore.ToString());
    }
    public void EndGame()
    {
        if (!isRunning) return;
        isRunning = false;
        SceneManager.LoadScene("GameOver"); // upewnij siê, ¿e scena ma dok³adnie tak¹ nazwê i jest w Build Settings
    }

    public string GetFormattedTime()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60f);
        int seconds = Mathf.FloorToInt(elapsedTime % 60f);
        int fraction = Mathf.FloorToInt((elapsedTime - Mathf.Floor(elapsedTime)) * 100f);
        return string.Format("{0:00}:{1:00}.{2:00}", minutes, seconds, fraction);
    }
}
