using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;

    [SerializeField, Tooltip("Prevents jumping when the transform is in mid-air.")]
    GroundCheck groundCheck;


    void Reset()
    {
        // Deteccion de que no se encuentre en el aire.
        groundCheck = GetComponentInChildren<GroundCheck>();
    }

    void Awake()
    {
        // Obtener RB.
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        // Saltar cuando se presione la tecla correspondiente.
        if (Input.GetButtonDown("Jump") && (!groundCheck || groundCheck.isGrounded))
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
