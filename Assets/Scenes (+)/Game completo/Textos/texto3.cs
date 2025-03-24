using UnityEngine;

public class texto3 : MonoBehaviour
{
    public GameObject messagePanel2; // Referencia al panel de la UI
    private bool hasBeenActivated = false; // Variable para verificar si ya se activó

    void Start()
    {
        if (messagePanel2 != null)
            messagePanel2.SetActive(false); // Asegurarse de que el panel comience oculto
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasBeenActivated) // Solo se activa si no ha sido activado antes
        {
            hasBeenActivated = true; // Marcamos que ya fue activado
            ShowPanel();
        }
    }

    void ShowPanel()
    {
        if (messagePanel2 != null)
        {
            messagePanel2.SetActive(true); // Muestra el panel
            Invoke("HidePanel", 6f); // Lo oculta después de 2 segundos (puedes cambiar el tiempo)
        }
    }

    void HidePanel()
    {
        if (messagePanel2 != null)
            messagePanel2.SetActive(false); // Oculta el panel
    }
}
