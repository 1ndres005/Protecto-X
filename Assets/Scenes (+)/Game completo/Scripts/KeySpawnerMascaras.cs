using UnityEngine;

public class KeySpawnerMasks : MonoBehaviour
{
    public GameObject keyPrefab;
    public Transform spawnPoint;

    public void SpawnKey()
    {
        Instantiate(keyPrefab, spawnPoint.position, Quaternion.identity);
    }
}




