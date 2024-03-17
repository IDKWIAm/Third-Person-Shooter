using UnityEngine;

public class GrenadePickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var grenade = other.gameObject.GetComponent<GrenadeCaster>();
        if (grenade != null)
        {
            grenade.grenadeAmount += 1;
            Destroy(gameObject);
        }
    }
}
