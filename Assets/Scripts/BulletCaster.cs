using UnityEngine;

public class BulletCaster : MonoBehaviour
{
    public Bullet BulletPrefab;

    public Transform bulletSource;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Instantiate(BulletPrefab, bulletSource.position, bulletSource.rotation);
        }
    }
}
