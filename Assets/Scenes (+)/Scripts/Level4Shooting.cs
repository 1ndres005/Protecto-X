using UnityEngine;
using TMPro;

public class Level4Shooting : MonoBehaviour
{
    public TMP_Text objectiveText; // Texto UI para el contador
    public GameObject keyLevel4; // Llave que aparecerá al destruir todos los objetivos
    private int destroyedObjects = 0;
    private int totalObjects = 5; // Número de objetos a destruir

    void Start()
    {
        UpdateUI();
        keyLevel4.SetActive(false); // Asegurar que la llave está desactivada al inicio
    }

    public void ObjectDestroyed()
    {
        destroyedObjects++;
        UpdateUI();

        if (destroyedObjects >= totalObjects)
        {
            UnlockKey();
        }
    }

    void UpdateUI()
    {
        if (objectiveText != null)
        {
            objectiveText.text = $"Objetivos: {destroyedObjects} / {totalObjects}";
        }
    }

    void UnlockKey()
    {
        if (keyLevel4 != null)
        {
            keyLevel4.SetActive(true); // Aparece la llave cuando se destruyen todos los objetos
        }
    }
}
