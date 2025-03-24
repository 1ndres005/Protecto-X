using UnityEngine;
using TMPro;

public class Level4ObjectiveTracker : MonoBehaviour
{
    public GameObject keyObject; // La llave que se activará
    private int destroyedObjects = 0; // Contador de objetos destruidos
    private int totalTargets = 5; // Número total de objetivos
    public TextMeshProUGUI timerText; // UI del tiempo restante

    public float timeLimit = 120f; // Tiempo límite en segundos (2 minutos)
    private float currentTime;
    private bool timeOut = false;

    private PlayerHealth playerHealth;

    void Start()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(false); // La llave inicia oculta
        }

        currentTime = timeLimit;
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    void Update()
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
        destroyedObjects++;

        if (destroyedObjects >= totalTargets)
        {
            ActivateKey();
        }
    }

    private void ActivateKey()
    {
        if (keyObject != null)
        {
            keyObject.SetActive(true); // Muestra la llave
        }
    }

    private void UpdateTimerUI()
    {
        timerText.text = "Tiempo restante: " + Mathf.Ceil(currentTime) + "s";
    }

    private void HandleTimeOut()
    {
        Debug.Log("⏳ Tiempo agotado, perdiendo una vida...");
        playerHealth.TakeDamage();
    }
}
