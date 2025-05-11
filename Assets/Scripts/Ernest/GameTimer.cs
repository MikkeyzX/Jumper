using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // UI Tekst z timera
    private float timeElapsed;
    private bool timerRunning = true;

    void Update()
    {
        if (timerRunning)
        {
            timeElapsed += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60f);
        int seconds = Mathf.FloorToInt(timeElapsed % 60f);
        timerText.text = minutes.ToString("00") + ":" + seconds.ToString("00");
    }

    public void StopTimer()
    {
        timerRunning = false;
    }
}
