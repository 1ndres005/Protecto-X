using UnityEngine;

public class Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca el peligro (lava o agua)
        {
            other.GetComponent<PlayerHealth>()?.TakeDamage();
        }
    }
}
