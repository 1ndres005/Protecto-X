using UnityEngine;

public class DangerousObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(); // El jugador pierde una vida
        }
    }
}
