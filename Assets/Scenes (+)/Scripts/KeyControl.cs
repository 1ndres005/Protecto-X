using UnityEngine;
using TMPro;

public class KeyCollector : MonoBehaviour
{
    public TMP_Text keyText; // Referencia al contador de llaves en la UI
    public TMP_Text finalMessage; // Referencia al mensaje final en la UI
    public GameObject finalObject; // Objeto final (cofre, puerta, etc.)
    private int keyCount = 0; // Contador de llaves
    private int totalKeys = 4; // Número de llaves requeridas

    void Start()
    {
        keyText.text = "Llaves: 0 / " + totalKeys; // Inicializa la UI
        finalMessage.gameObject.SetActive(false); // Oculta el mensaje final
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Key")) // Si toca una llave
        {
            keyCount++;
            UpdateUI();
            Destroy(other.gameObject); // Destruye la llave
        }

        if (other.CompareTag("FinalObject") && keyCount >= totalKeys) // Si toca el objeto final con las 4 llaves
        {
            UnlockFinalObject();
        }
    }

    void UpdateUI()
    {
        keyText.text = "Llaves: " + keyCount + " / " + totalKeys;
    }

    void UnlockFinalObject()
    {
        Destroy(finalObject); // Destruye el objeto final
        finalMessage.text = "¡Felicitaciones Piratilla! Es tuyo el tesoro.";
        finalMessage.gameObject.SetActive(true); // Muestra el mensaje final en pantalla
        Debug.Log("El juego ha finalizado."); // Mensaje en consola
    }
}
