using UnityEngine;
using UnityEngine.UI;

public class CrosshairController : MonoBehaviour
{
    public GameObject crosshair; // Referencia a la imagen del punto de mira
    public GameObject playerWeapon; // Referencia al arma del jugador

    void Start()
    {
        crosshair.SetActive(false); // El crosshair empieza desactivado
    }

    void Update()
    {
        if (playerWeapon.activeSelf)
        {
            crosshair.SetActive(true); // Activar el crosshair si el arma está activa
        }
        else
        {
            crosshair.SetActive(false); // Desactivarlo si el arma no está equipada
        }
    }
}