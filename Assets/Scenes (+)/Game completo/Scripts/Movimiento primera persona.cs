using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;

    [Header("Running")]
    public bool canRun = true;
    public bool IsRunning { get; private set; }
    public float runSpeed = 9;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody rigidbody;
    /// <summary> </summary>
    public List<System.Func<float>> speedOverrides = new List<System.Func<float>>();

    [Header("Animaciones")]
    [SerializeField] private Animator animator;

    void Awake()
    {
        // Obtener RB
        rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Actualizar que pueda correr
        IsRunning = canRun && Input.GetKey(runningKey);

        // Aumento de velocidad
        float targetMovingSpeed = IsRunning ? runSpeed : speed;
        if (speedOverrides.Count > 0)
        {
            targetMovingSpeed = speedOverrides[speedOverrides.Count - 1]();
        }

        // Dirección
        Vector2 targetVelocity =new Vector2( Input.GetAxis("Horizontal") * targetMovingSpeed, Input.GetAxis("Vertical") * targetMovingSpeed);

        // Aplica movimiento
        rigidbody.velocity = transform.rotation * new Vector3(targetVelocity.x, rigidbody.velocity.y, targetVelocity.y);

        if (targetVelocity.x != 0 || targetVelocity.y != 0) animator?.SetFloat("Speed", 1);
        else animator?.SetFloat("Speed", 0);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FinalObject"))// Al entrar en contacto con el objeto final deshabilitara el movimiento del jugador
        { 
                GetComponent<FirstPersonMovement>().enabled = false; // Deshabilita el movimiento
        }
    }
}