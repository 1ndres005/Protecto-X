using UnityEngine;
using TMPro;

public class TimerUI : MonoBehaviour
{
    public TMP_Text timerText;
    private float timeRemaining = 120f; // 2 minutos
    private bool isRunning = false;

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
        UpdateUI();
    }

    void Update()
    {
        if (isRunning && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        timerText.text = $"Tiempo: {Mathf.Ceil(timeRemaining)}s";
    }
}