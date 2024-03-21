using UnityEngine;

public class GrenadePickUp : MonoBehaviour
{
    public AudioSource grenadePickUpSound;

    private void OnTriggerEnter(Collider other)
    {
        var grenade = other.gameObject.GetComponent<GrenadeCaster>();
        if (grenade != null)
        {
            grenadePickUpSound.PlayOneShot(grenadePickUpSound.clip);
            grenade.grenadeAmount += 1;
            Destroy(gameObject);
        }
    }
}
