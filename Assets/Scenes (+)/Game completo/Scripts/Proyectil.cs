using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float destroyDelay = 0.5f;
    private ObjectiveCounterBottles counterBottles;
    private ObjectiveCounterMasks counterMasks;

    void Start()
    {
        counterBottles = FindObjectOfType<ObjectiveCounterBottles>();
        counterMasks = FindObjectOfType<ObjectiveCounterMasks>();

        Destroy(gameObject, 5f);  
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bottle") && counterBottles != null)
        {
            counterBottles.UpdateCounter();
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("Mask") && counterMasks != null)
        {
            counterMasks.UpdateCounter();
            Destroy(other.gameObject);
        }

        Destroy(gameObject, destroyDelay);
    }
}






