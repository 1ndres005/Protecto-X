using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 20f;
    private bool canShoot = false;
    public GameObject crosshair; // Referencia al crosshair (mira)

    void Update()
    {
        if (canShoot && Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    public void EnableShooting()
    {
        canShoot = true;
        if (crosshair != null)
        {
            crosshair.SetActive(true); // Activar la mira
        }
    }

    public void DisableWeapon()
    {
        canShoot = false;
        if (crosshair != null)
        {
            crosshair.SetActive(false); // Ocultar la mira
        }
    }

    private void Shoot()
    {
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = firePoint.forward * projectileSpeed;
    }
}

