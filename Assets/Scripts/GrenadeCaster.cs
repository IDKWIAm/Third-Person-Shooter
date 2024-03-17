using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float force = 10f;
    public int grenadeAmount = 0;

    public GameObject grenadePrefab;
    public Transform grenadeSourceTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            if (grenadeAmount > 0)
            {
                grenadeAmount -= 1;
                var grenade = Instantiate(grenadePrefab, grenadeSourceTransform.position, grenadeSourceTransform.rotation);
                grenade.transform.Rotate(90, 0, 0);
                grenade.transform.GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
            }
        }
    }
}
