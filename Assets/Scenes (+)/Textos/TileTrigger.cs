using UnityEngine;

public class TileTrigger : MonoBehaviour
{
    public GameObject messagePanel; // Referencia al panel de la UI
    private float messageDuration = 5f; // Tiempo que el panel estará visible

    void Start()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // Asegurarse de que el panel comienza oculto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador pisa el cubo
        {
            ShowPanel();
        }
    }

    void ShowPanel()
    {
        if (messagePanel != null)
        {
            messagePanel.SetActive(true); // Muestra el panel
            CancelInvoke("HidePanel"); // Reinicia el temporizador si ya estaba activo
            Invoke("HidePanel", messageDuration); // Ocultar después de un tiempo
        }
    }

    void HidePanel()
    {
        if (messagePanel != null)
            messagePanel.SetActive(false); // Oculta el panel después del tiempo establecido
    }

 
}
