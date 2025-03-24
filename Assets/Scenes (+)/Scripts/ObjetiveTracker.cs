using UnityEngine;
using TMPro;

public class ObjectiveTracker : MonoBehaviour
{
    public int totalObjectives = 9;
    private int remainingObjectives;
    public TextMeshProUGUI objectivesText; // UI contador de objetivos
    public GameObject specialObject; // Objeto que se activa al completar los objetivos
    public TextMeshProUGUI timerText; // UI del tiempo restante

    public float timeLimit = 120f; // Tiempo límite en segundos (2 minutos)
    private float currentTime;
    private bool timeOut = false;

    private PlayerHealth playerHealth;

    private void Start()
    {
        remainingObjectives = totalObjectives;
        UpdateUI();
        specialObject.SetActive(false); // Mantener oculto el objeto especial
        currentTime = timeLimit;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if (!timeOut)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerUI();

            if (currentTime <= 0)
            {
                timeOut = true;
                HandleTimeOut();
            }
        }
    }

    public void ObjectDestroyed()
    {
        remainingObjectives--;
        UpdateUI();

        if (remainingObjectives <= 0)
        {
            ActivateSpecialObject();
        }
    }

    private void UpdateUI()
    {
        objectivesText.text = "Objetivos restantes: " + remainingObjectives;
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Tiempo restante: " + Mathf.Ceil(currentTime) + "s";
    }

    private void ActivateSpecialObject()
    {
        specialObject.SetActive(true); // Mostrar el objeto especial al completar los objetivos
    }

    private void HandleTimeOut()
    {
        Debug.Log("⏳ Tiempo agotado, perdiendo una vida...");
        playerHealth.TakeDamage();
    }
}

