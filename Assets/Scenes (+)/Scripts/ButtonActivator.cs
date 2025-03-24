using UnityEngine;

public class ButtonActivator : MonoBehaviour
{
    public GameObject targetObject; // Objeto que será destruido al activar el botón
    private bool isPlayerInRange = false;

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.F))
        {
            ActivateButton();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    private void ActivateButton()
    {
        if (targetObject != null)
        {
            Destroy(targetObject); // Destruye el objeto asignado
        }
        Destroy(gameObject); // Opcional: Destruir el botón después de la activación
    }
}
