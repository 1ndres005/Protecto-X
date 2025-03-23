using UnityEngine;
using TMPro;  // Importamos TextMeshPro

public class ObjectiveCounterBottles : MonoBehaviour
{
    public int totalBottles = 9;
    private int bottlesDestroyed = 0;
    public KeySpawnerBottles keySpawner;  
    public TMP_Text bottleCounterText; // UI con TextMeshPro

    void Start()
    {
        UpdateUI();
    }

    public void UpdateCounter()
    {
        bottlesDestroyed++;
        UpdateUI();

        if (bottlesDestroyed >= totalBottles)
        {
            keySpawner.SpawnKey();
        }
    }

    private void UpdateUI()
    {
        if (bottleCounterText != null)
        {
            bottleCounterText.text = $"Botellas: {bottlesDestroyed}/{totalBottles}";
        }
    }
}

