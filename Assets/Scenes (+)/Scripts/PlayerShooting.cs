using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [Header("Disparo")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public float fireRate = 0.5f;
    private float nextFireTime = 0f;

    [Header("Recolectar Arma")]
    private bool canShoot = false;

    [Header("UI")]
    public GameObject crosshair;
    public GameObject playerWeapon; // Referencia al arma del jugador
    public TimerUI timerUI;

    void Start()
    {
        DisableWeapon(); // El arma inicia invisible
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
                rb.velocity = firePoint.forward * bulletSpeed;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("WeaponPickup")) // Detectar cualquier arma con esta etiqueta
        {
            EnableWeapon();
            Destroy(other.gameObject); // Destruir solo el arma recogida
        }
    }

    public void EnableWeapon()
    {
        canShoot = true;
        if (crosshair != null) crosshair.SetActive(true);
        if (playerWeapon != null) playerWeapon.SetActive(true); // Mostrar el arma

        if (timerUI != null)
        {
            timerUI.ResetTimer(); // Reiniciar el temporizador al recoger el arma
            timerUI.StartTimer(); // Asegurar que se inicie
        }
    }

    public void DisableWeapon()
    {
        canShoot = false;
        if (crosshair != null) crosshair.SetActive(false);
        if (playerWeapon != null) playerWeapon.SetActive(false); // Ocultar el arma
    }
}

