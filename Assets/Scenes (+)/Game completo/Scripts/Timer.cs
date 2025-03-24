using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TMP_Text timerText;
    public float timeRemaining = 120f;
    private bool isRunning = false;

    void Start()
    {
        timerText.text = "02:00";
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimerUI();
        }
    }

    void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public void ResetTimer()
    {
        timeRemaining = 120f;
        isRunning = true;
        UpdateTimerUI();
    }
}




