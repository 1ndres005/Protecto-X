using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeLimit = 120f; // 2 minutos
    private float remainingTime;
    private bool isRunning = false;
    public TextMeshProUGUI timerText; // Texto en la UI

    private void Start()
    {
        timerText.gameObject.SetActive(false); // Ocultar el temporizador al inicio
    }

    private void Update()
    {
        if (isRunning)
        {
            remainingTime -= Time.deltaTime;
            UpdateUI();

        }
    }

    public void StartTimer()
    {
        remainingTime = timeLimit;
        isRunning = true;
        timerText.gameObject.SetActive(true); // Mostrar temporizador en UI
    }

    private void UpdateUI()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}




