using UnityEngine;

public class LevelTrigger : MonoBehaviour
{
    public int levelObjects; // Número de objetos en este nivel

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ObjectiveCounterMasks counter = FindObjectOfType<ObjectiveCounterMasks>();
            if (counter != null)
            {
                counter.SetLevelObjective(levelObjects);
            }
        }
    }
}
