using UnityEngine;

public class Aidkit : MonoBehaviour
{
    public float healAmount = 50f;
    public AudioSource energyCellPickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        var playerHealth = other.gameObject.GetComponent<PlayerHealth>();

        if (playerHealth != null)
        {
            energyCellPickUpSound.PlayOneShot(energyCellPickUpSound.clip);

            playerHealth.AddHealth(healAmount);
            Destroy(gameObject);
        }
    }
}
