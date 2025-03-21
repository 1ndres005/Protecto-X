using UnityEngine;

public class SpawnPointyCheckpoint : MonoBehaviour
{
    // Checkpoint
    private Vector3 lastCheckpointPosition;
    public Transform spawnPoint;

    public void GuardarCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpointPosition = checkpointPos;
        Debug.Log("Checkpoint guardado en: " + lastCheckpointPosition);
    }

    void Start()
    {
       
        lastCheckpointPosition = spawnPoint ? spawnPoint.position : transform.position;
        transform.position = lastCheckpointPosition;
    }

    void Update()
    {

        if (transform.position.y < -10) // Si el jugador cae del mapa
        {
            ReaparecerEnCheckpoint();
        }
    }

    public void ReaparecerEnCheckpoint()
    {
        if (lastCheckpointPosition != Vector3.zero)
        {
            Vector3 spawnPosition = lastCheckpointPosition + Vector3.up * 1.5f;
            transform.position = spawnPosition;
            Debug.Log("Reapareciendo en checkpoint: " + spawnPosition);
        }
        else
        {
            Debug.LogWarning("No hay un checkpoint guardado, reapareciendo en el inicio.");
        }
    }
}
