using UnityEngine;

[ExecuteInEditMode]
public class GroundCheck : MonoBehaviour
{
    [Tooltip("Maximum distance from the ground.")]
    public float distanceThreshold = .15f;

    [Tooltip("Whether this transform is grounded now.")]
    public bool isGrounded = true;
    /// <summary>
    /// Llamar cuando el jugador collisiones con el suelo.
    /// </summary>
    public event System.Action Grounded;

    const float OriginOffset = .001f;
    Vector3 RaycastOrigin => transform.position + Vector3.up * OriginOffset;
    float RaycastDistance => distanceThreshold + OriginOffset;


    void LateUpdate()
    {
        // Chequea que se encuentre el suelo.
        bool isGroundedNow = Physics.Raycast(RaycastOrigin, Vector3.down, distanceThreshold * 2);

        // llama el evento en caso de que el jugador no detecte el suelo.
        if (isGroundedNow && !isGrounded)
        {
            Grounded?.Invoke();
        }

        // Actualiza cuando vuelve a tocar el suelo.
        isGrounded = isGroundedNow;
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja linea en el suelo para que en el motor se pueda configurar.
        Debug.DrawLine(RaycastOrigin, RaycastOrigin + Vector3.down * RaycastDistance, isGrounded ? Color.white : Color.red);
    }
}
