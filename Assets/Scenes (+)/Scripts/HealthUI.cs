using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText; // UI para mostrar corazones en texto
    public PlayerHealth playerHealth;

    void Start()
    {
        PlayerHealth.HealthChanged += UpdateUI; // Suscribirse al evento de cambio de vida
        UpdateUI(playerHealth.CurrentHealth); // Inicializar UI
    }

    void OnDestroy()
    {
        PlayerHealth.HealthChanged -= UpdateUI; // Desuscribirse del evento
    }

    void UpdateUI(int currentHealth)
    {
        healthText.text = "Vidas: " + currentHealth;
    }
}
