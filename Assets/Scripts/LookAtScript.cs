using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public Transform target;
    public float offsetY = 0f;

    void Update()
    {
        transform.LookAt(target.position + new Vector3(0, offsetY, 0));
    }
}
