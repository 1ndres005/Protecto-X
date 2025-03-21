using UnityEngine;

public class PlayerShooting : MonoBehaviour

{
    [Header("Disparo")]
    public GameObject bulletPrefab; // Prefab del proyectil
    public Transform firePoint; // Punto de disparo
    public float bulletSpeed = 20f; // Velocidad del proyectil
    public float fireRate = 0.5f; // Tiempo entre disparos
    private float nextFireTime = 0f; // Control del tiempo de disparo

    [Header("Objeto Recolectable")]
    public GameObject pickupItem; // Objeto a recoger
    private bool canShoot = false; // ¿Puede disparar?

    void Start()
    {
        if (pickupItem != null)
        {
            pickupItem.SetActive(true); // Asegura que el objeto esté activo
        }
    }

    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && firePoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = firePoint.forward * bulletSpeed;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pickupItem) // Si el jugador toca el objeto
        {
            canShoot = true; // Habilita el disparo
            Destroy(pickupItem); // Destruye el objeto recolectable
        }
    }
}


