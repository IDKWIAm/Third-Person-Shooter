using UnityEngine;

public class GrenadeCaster : MonoBehaviour
{
    public float force = 10f;

    public GameObject grenadePrefab;
    public Transform grenadeSourceTransform;

    void Update()
    {
        if (Input.GetMouseButtonDown(2))
        {
            var grenade = Instantiate(grenadePrefab, grenadeSourceTransform.position, grenadeSourceTransform.rotation);
            //grenade.transform.position = grenadeSourceTransform.position;
            //grenade.transform.rotation = Quaternion.identity;
            grenade.transform.GetChild(0).GetComponent<Rigidbody>().AddForce(grenadeSourceTransform.forward * force);
        }
    }
}
