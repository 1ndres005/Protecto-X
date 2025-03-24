using UnityEngine;

public class DestructibleObject : MonoBehaviour
{
    public ObjectiveTracker objectiveTracker; // Para el nivel 2
    public Level4Shooting level4Shooting; // Para el nivel 4
    public bool isLevel4Object = false; // Identifica si es un objeto del nivel 4

    public void TakeDamage()
    {
        if (isLevel4Object)
        {
            if (level4Shooting != null)
            {
                level4Shooting.ObjectDestroyed(); // Notifica al contador del nivel 4
            }
            else
            {
                Debug.LogWarning("⚠️ Level4Shooting no está asignado en " + gameObject.name);
            }
        }
        else
        {
            if (objectiveTracker != null)
            {
                objectiveTracker.ObjectDestroyed(); // Notifica al contador del nivel 2
            }
            else
            {
                Debug.LogWarning("⚠️ ObjectiveTracker no está asignado en " + gameObject.name);
            }
        }

        Destroy(gameObject); // Destruye el objeto al recibir daño
    }

    private void OnTriggerEnter(Collider other) // 🔄 Cambiamos OnCollisionEnter por OnTriggerEnter
    {
        if (other.CompareTag("Projectile"))
        {
            Debug.Log("🔴 Objeto destruido: " + gameObject.name); // Verificar que se está destruyendo correctamente
            TakeDamage();
            Destroy(other.gameObject); // Destruir el proyectil después del impacto
        }
    }
}
