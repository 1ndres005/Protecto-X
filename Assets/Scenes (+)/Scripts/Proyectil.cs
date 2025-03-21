using UnityEngine;
using TMPro; // Para manejar la UI con TextMeshPro

public class Projectile : MonoBehaviour
{
    public float destroyDelay = 0.5f; // Tiempo antes de autodestruirse
    public string[] targetTags = { "Enemy", "TargetObject" }; // Tags de los objetos válidos
    public static int objectsDestroyed = 0; // Contador global

    [Header("UI")]
    public TMP_Text counterText; // Referencia al contador en la UI

    void Start()
    {
        // Destruir el proyectil automáticamente después de 5 segundos si no impacta nada
        Destroy(gameObject, 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si el objeto impactado tiene un tag válido
        foreach (string tag in targetTags)
        {
            if (other.CompareTag(tag))
            {
                objectsDestroyed++; // Incrementa el contador
                UpdateUI(); // Actualiza el contador en la UI
                Destroy(other.gameObject); // Destruye el objeto impactado
                Destroy(gameObject, destroyDelay); // Destruye el proyectil
                return;
            }
        }
    }

    void UpdateUI()
    {
        if (counterText != null)
        {
            counterText.text = "Objetos destruidos: " + objectsDestroyed;
        }
    }
}
