using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    public GameObject playerWeapon; // Referencia al arma del jugador (inicialmente invisible)
    public GameObject weaponOnGround; // Arma visible en el suelo
    public GameObject crosshair; // Punto de mira en la UI
    public PlayerShooting playerShooting; // Referencia al script de disparo
    public Timer timer; // Referencia al temporizador

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerWeapon.SetActive(true); // Hacer visible el arma del jugador
            weaponOnGround.SetActive(false); // Ocultar el arma en el suelo
            crosshair.SetActive(true); // Activar el punto de mira en la UI
            playerShooting.EnableShooting(); // Habilitar la mecánica de disparo
            timer.StartTimer(); // Iniciar el temporizador de 2 minutos
        }
    }
}