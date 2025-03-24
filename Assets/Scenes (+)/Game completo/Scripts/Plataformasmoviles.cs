using UnityEngine;

public class PlataformaMovil : MonoBehaviour
{
    [Header("Puntos de movimiento")]
    public Transform puntoA;
    public Transform puntoB;
    public float velocidad = 3f;

    private Vector3 destinoActual;

    void Start()
    {
        destinoActual = puntoB.position;
    }

    void Update()
    {
        // Mueve la plataforma entre los puntos A y B
        transform.position = Vector3.MoveTowards(transform.position, destinoActual, velocidad * Time.deltaTime);

        // Cambia de dirección cuando llega al destino
        if (Vector3.Distance(transform.position, destinoActual) < 0.1f)
        {
            destinoActual = (destinoActual == puntoB.position) ? puntoA.position : puntoB.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hacer que el jugador sea hijo de la plataforma
            other.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Quitar la paternidad para que el jugador no se mueva con la plataforma
            other.transform.SetParent(null);
        }
    }
}