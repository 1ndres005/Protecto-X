using UnityEngine;
using TMPro;

public class PickupItemUI : MonoBehaviour
{
    public string itemName = "Llave"; // Nombre del objeto
    public TMP_Text pickupText; // Referencia al texto en la UI

    void Start()
    {
        if (pickupText != null)
        {
            pickupText.gameObject.SetActive(false); // Oculta el texto al inicio
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador lo recoge
        {
            ShowPickupMessage();
            Destroy(gameObject); // Destruye el objeto
        }
    }

    void ShowPickupMessage()
    {
        if (pickupText != null)
        {
            pickupText.text = "¡Has obtenido: " + itemName + "!";
            pickupText.gameObject.SetActive(true);
            Invoke("HidePickupMessage", 2f); // Oculta el mensaje después de 2 segundos
        }
    }

    void HidePickupMessage()
    {
        pickupText.gameObject.SetActive(false);
    }
}