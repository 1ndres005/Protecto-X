using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float speed = 20f;
    public float maxLifetime = 3f; // Tiempo máximo antes de autodestruirse
    public Rigidbody rb;

    void Start()
    {
        if (rb == null)
        {
            Debug.LogError("⚠️ ERROR: No se ha asignado un Rigidbody en el script Proyectil.");
            return;
        }

        rb.velocity = transform.forward * speed;
        Destroy(gameObject, maxLifetime); // Destruir después de un tiempo para evitar objetos persistentes
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("💥 Impacto con: " + collision.collider.name); // Ver qué objeto está tocando el proyectil

        DestructibleObject destructible = collision.collider.GetComponent<DestructibleObject>();

        if (destructible != null)
        {
            Debug.Log("✅ Objeto destructible detectado y destruido: " + collision.collider.name);
            destructible.TakeDamage(); // Llama al método en DestructibleObject
        }
        else
        {
            Debug.Log("🚫 El objeto impactado NO es destructible: " + collision.collider.name);
        }

        Destroy(gameObject); // Destruye el proyectil después del impacto
    }
}

