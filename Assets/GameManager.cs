using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timeText;
    public Text finalScoreText;

    public float maxLevelTime = 120f; // Maksymalny czas dla punktów bonusowych
    private float timer = 0f;
    private int coinsCollected = 0;
    private bool levelEnded = false;

    void Update()
    {
        if (!levelEnded)
        {
            timer += Time.deltaTime;
            timeText.text = "Czas: " + timer.ToString("F1") + "s";
        }
    }

    public void AddCoin()
    {
        coinsCollected++;
    }

    public void EndLevel()
    {
        levelEnded = true;

        int coinPoints = coinsCollected * 10;
        float timeBonus = Mathf.Max(0, (maxLevelTime - timer)) * 2f;
        int finalScore = coinPoints + Mathf.RoundToInt(timeBonus);

        finalScoreText.text = "WYNIK: " + finalScore;
        finalScoreText.gameObject.SetActive(true);
        Debug.Log("Wynik koñcowy: " + finalScore);
    }
}
