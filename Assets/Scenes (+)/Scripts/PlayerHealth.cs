using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;

    private SpawnPointyCheckpoint checkpointSystem;

    // Propiedad pública para acceder a la salud
    public int CurrentHealth => currentHealth;

    public delegate void OnHealthChanged(int currentHealth);
    public static event OnHealthChanged HealthChanged;

    void Start()
    {
        currentHealth = maxHealth;
        checkpointSystem = GetComponent<SpawnPointyCheckpoint>();
    }

    public void TakeDamage()
    {
        currentHealth--;
        Debug.Log("💔 Vida restante: " + currentHealth);

        HealthChanged?.Invoke(currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("💀 Juego terminado");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Respawn();
        }
    }

    private void Respawn()
    {
        if (checkpointSystem != null)
        {
            Vector3 respawnPosition = checkpointSystem.GetLastCheckpoint();
            transform.position = respawnPosition + Vector3.up * 1.5f;
            Debug.Log("🔄 Reapareciendo en checkpoint: " + respawnPosition);
        }
        else
        {
            Debug.LogWarning("⚠️ No hay checkpoint guardado. Reapareciendo en el inicio.");
            transform.position = Vector3.zero;
        }
    }
}
