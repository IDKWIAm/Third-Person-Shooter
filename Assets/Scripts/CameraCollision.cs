using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float rayDistance;

    public Transform cameraAxis;

    void Update()
    {
        var ray = (transform.parent.position - cameraAxis.position).normalized;

        RaycastHit hit;
        if (Physics.Raycast(cameraAxis.position + new Vector3(0, 1, 0), ray, out hit, rayDistance))
        {

            transform.position = hit.point;
        }
        else
        {
            transform.position = transform.parent.position;
        }
    }
}
