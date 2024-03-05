using UnityEngine;

public class Grenade : MonoBehaviour
{
    public float delay = 3;
    public GameObject explosionPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        Explosion();
        //Invoke("Explosion", delay);
    }

    private void Explosion()
    {
        Destroy(gameObject.transform.parent.gameObject);

        var explosion = Instantiate(explosionPrefab);
        explosion.transform.position = transform.position;
    }
}
