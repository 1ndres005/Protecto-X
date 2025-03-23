using UnityEngine;
using TMPro;

public class ObjectiveCounterMasks : MonoBehaviour
{
    public int totalMasks = 5;
    private int masksDestroyed = 0;
    public KeySpawnerMasks keySpawner;
    public TMP_Text maskCounterText; // UI con TextMeshPro

    void Start()
    {
        UpdateUI();
    }

    public void UpdateCounter()
    {
        masksDestroyed++;
        UpdateUI();

        if (masksDestroyed >= totalMasks)
        {
            keySpawner.SpawnKey();
        }
    }

    private void UpdateUI()
    {
        if (maskCounterText != null)
        {
            maskCounterText.text = $"Máscaras: {masksDestroyed}/{totalMasks}";
        }
    }

    public void SetLevelObjective(int levelObjects)
    {
        totalMasks = levelObjects;
        UpdateUI();
    }
}


