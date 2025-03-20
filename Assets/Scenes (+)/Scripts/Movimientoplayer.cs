using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento del jugador")]
    public CharacterController controller;
    public float speed = 5f;
    public float sprintMultiplier = 1.5f; // Multiplicador de velocidad al sprintar
    public float jumpHeight = 2f;
    public float gravity = -9.81f;
    
    [Header("Cámara del jugador")]
    public Transform playerCamera;
    public float mouseSensitivity = 100f;
    private float xRotation = 0f;
    
    [Header("Detección de suelo")]
    public Transform groundCheck;
    public LayerMask groundMask;
    private Vector3 velocity;
    private bool isGrounded;

    [Header("Animaciones")]
    [SerializeField] private Animator animator;

    [Header("Ataque")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    [Header("Agarre de bordes")]
    public Transform edgeCheck;
    public float edgeGrabDistance = 0.5f;
    public bool isHanging = false;

    // Checkpoint
    private Vector3 lastCheckpointPosition;
    public Transform spawnPoint;

    public void GuardarCheckpoint(Vector3 checkpointPos)
    {
        lastCheckpointPosition = checkpointPos;
        Debug.Log("Checkpoint guardado en: " + lastCheckpointPosition);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        lastCheckpointPosition = spawnPoint ? spawnPoint.position : transform.position;
        transform.position = lastCheckpointPosition;
    }

    void Update()
    {
        MovimientoJugador();
        RotacionCamara();
        DetectarBorde();

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Saltar();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Atacar();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            ActivarDispositivo();
        }
        if (transform.position.y < -10) // Si el jugador cae del mapa
        {
            ReaparecerEnCheckpoint();
        }
    }

    void MovimientoJugador()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.4f, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        Vector3 moveDirection = (playerCamera.forward * moveZ + playerCamera.right * moveX).normalized;
        moveDirection.y = 0;

        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed *= sprintMultiplier;
        }

        if (moveX != 0 || moveZ != 0) animator?.SetFloat("Speed", 1);
        else animator?.SetFloat("Speed", 0);

        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void Saltar()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
       
    }

    void RotacionCamara()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        transform.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    void Atacar()
    {
        
        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>()?.TakeDamage(10);
        }
    }

    void ActivarDispositivo()
    {
        Debug.Log("Dispositivo activado");
    }

    void DetectarBorde()
    {
        RaycastHit hit;
        if (Physics.Raycast(edgeCheck.position, Vector3.down, out hit, edgeGrabDistance))
        {
            if (!isGrounded && hit.collider != null)
            {
                isHanging = true;
                velocity.y = 0;
            }
        }
        else
        {
            isHanging = false;
        }
    }

    public void ReaparecerEnCheckpoint()
    {
        if (lastCheckpointPosition != Vector3.zero)
        {
            Vector3 spawnPosition = lastCheckpointPosition + Vector3.up * 1.5f;
            controller.enabled = false;
            transform.position = spawnPosition;
            controller.enabled = true;
            Debug.Log("Reapareciendo en checkpoint: " + spawnPosition);
        }
        else
        {
            Debug.LogWarning("No hay un checkpoint guardado, reapareciendo en el inicio.");
        }
    }
}