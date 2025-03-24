using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class textovictorio : MonoBehaviour
{
public GameObject Cofrefinal; // Referencia al panel de la UI
    private bool hasBeenActivated = false; // Variable para verificar si ya se activó

    void Start()
    {
        if (Cofrefinal != null)
            Cofrefinal.SetActive(false); // Asegurarse de que el panel comience oculto
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
        if (Cofrefinal != null)
        {
            Cofrefinal.SetActive(true); // Muestra el panel
            Invoke("HidePanel", 6f); // Lo oculta después de 2 segundos (puedes cambiar el tiempo)
        }
    }

    void HidePanel()
    {
        if (Cofrefinal != null)
            Cofrefinal.SetActive(false); // Oculta el panel
    }
}
