using UnityEngine;

public class SpawnPointyCheckpoint : MonoBehaviour
{
    private Vector3 lastCheckpointPosition;
    public Transform spawnPoint;

    void Start()
    {
        lastCheckpointPosition = spawnPoint ? spawnPoint.position : transform.position;
    }

    public void GuardarCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpointPosition = checkpointPos;
        Debug.Log("Checkpoint guardado en: " + lastCheckpointPosition);
    }

    public Vector3 GetLastCheckpoint()
    {
        return lastCheckpointPosition;
    }
}


