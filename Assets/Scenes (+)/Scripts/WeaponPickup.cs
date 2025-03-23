using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject playerWeapon; // Referencia al arma del jugador
    public GameObject pickupWeapon; // Arma en el mapa

    void Start()
    {
        playerWeapon.SetActive(false); // Ocultar el arma del jugador al inicio
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerWeapon.SetActive(true); // Activar el arma del jugador
            pickupWeapon.SetActive(false); // Desaparecer el arma del mapa
        }
    }
}