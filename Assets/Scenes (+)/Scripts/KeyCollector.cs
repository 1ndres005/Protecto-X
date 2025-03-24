using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public int totalKeys = 4; // Ajusta el número total de llaves necesarias
    private int keyCount = 0;
    public TMP_Text keyText; // UI para mostrar las llaves recolectadas
    public GameObject finalObject; // Objeto que se desbloquea al recolectar todas las llaves

    void Start()
    {
        UpdateUI();
        if (finalObject != null)
        {
            finalObject.SetActive(false); // Asegurar que está desactivado al inicio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key") || other.CompareTag("KeyLevel4")) // Detecta llaves de cualquier nivel
        {
            keyCount++;
            UpdateUI();
            Destroy(other.gameObject);
        }

        if (other.CompareTag("FinalObject") && keyCount >= totalKeys)
        {
            UnlockFinalObject();
        }
    }

    void UpdateUI()
    {
        if (keyText != null)
        {
            keyText.text = $"Llaves: {keyCount} / {totalKeys}";
        }
    }

    void UnlockFinalObject()
    {
        if (finalObject != null)
        {
            finalObject.SetActive(true); // Activa el objeto final cuando se recolectan todas las llaves
        }
    }
}