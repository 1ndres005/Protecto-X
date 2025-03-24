using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public TMP_Text keyText; // Referencia al contador de llaves en la UI
    public TMP_Text finalMessage; // Mensaje de nivel completado
    public GameObject finalObject; // Objeto final (cofre, puerta, etc.)
    public TimerUI timerUI; // Referencia al temporizador
    public PlayerShooting playerShooting; // Referencia al disparo

    private int keyCount = 0; // Contador de llaves
    private int totalKeys = 4; // Número de llaves requeridas

    void Start()
    {
        keyText.text = $"Llaves: 0 / {totalKeys}";
        finalMessage.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key")) // Llave normal
        {
            keyCount++;
            UpdateUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("ShootingKey")) // Llave de disparo
        {
            keyCount++;
            UpdateUI();
            playerShooting.DisableWeapon(); // Desactiva el arma
            timerUI.StopTimer(); // Detiene el temporizador
            Destroy(other.gameObject);
        }

        if (other.CompareTag("MaskLevelTrigger")) // Si entra al nivel de máscaras
        {
            timerUI.ResetTimer(); // Reinicia el temporizador
        }

        if (other.CompareTag("FinalObject") && keyCount >= totalKeys) // Si abre el objeto final
        {
            UnlockFinalObject();
        }
    }

    void UpdateUI()
    {
        keyText.text = $"Llaves: {keyCount} / {totalKeys}";
    }

    void UnlockFinalObject()
    {
        finalMessage.gameObject.SetActive(true);
        finalMessage.text = "¡Objeto final desbloqueado!";
    }
}
