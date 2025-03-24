using System.Collections;
using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public int totalKeys = 4; // Número total de llaves necesarias
    private int keyCount = 0;
    public TMP_Text keyText; // UI para mostrar las llaves recolectadas
    public GameObject finalObject; // Cofre final que se desbloquea al recolectar todas las llaves
    public GameObject messagePanel; // Panel de mensaje que aparecerá al recolectar todas las llaves

    void Start()
    {
        UpdateUI();
        if (finalObject != null)
        {
            finalObject.SetActive(false); // Asegurar que el cofre final está oculto al inicio
        }
        if (messagePanel != null)
        {
            messagePanel.SetActive(false); // Asegurar que el panel de mensaje está oculto al inicio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") || other.CompareTag("KeyLevel4")) // Detecta llaves de cualquier nivel
        {
            keyCount++;
            UpdateUI();
            Destroy(other.gameObject);

            if (keyCount >= totalKeys)
            {
                if (messagePanel != null)
                {
                    messagePanel.SetActive(true); // Mostrar el panel de mensaje
                    StartCoroutine(HideMessagePanel()); // Ocultarlo después de 6 segundos
                }

                if (finalObject != null)
                {
                    finalObject.SetActive(true); // Mostrar el cofre final
                    Debug.Log("¡Cofre final activado!"); // Mensaje de depuración en la consola
                }
            }
        }
    }

    void UpdateUI()
    {
        if (keyText != null)
        {
            keyText.text = $"Llaves: {keyCount} / {totalKeys}";
        }
    }

    IEnumerator HideMessagePanel()
    {
        yield return new WaitForSeconds(6); // Esperar 6 segundos
        messagePanel.SetActive(false); // Ocultar el panel de mensaje
    }
}
