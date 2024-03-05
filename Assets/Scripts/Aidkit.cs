using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50f;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            playerHealth.AddHealth(healAmount);
            Destroy(gameObject.transform.parent.parent.gameObject);
        }
    }
}
