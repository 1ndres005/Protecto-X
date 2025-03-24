using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca el checkpoint
        {
            SpawnPointyCheckpoint spawnPointScript = other.GetComponent<SpawnPointyCheckpoint>();

            if (spawnPointScript != null)
            {
                spawnPointScript.GuardarCheckpoint(transform.position);
            }
            else
            {
                Debug.LogWarning("⚠️ El jugador no tiene el script SpawnPointyCheckpoint.");
            }
        }
    }
}
