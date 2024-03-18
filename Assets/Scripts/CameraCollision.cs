using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public Transform cameraAxis;
    public Transform defaultCamPos;

    void Update()
    {
        var ray = defaultCamPos.position - cameraAxis.position;

        RaycastHit hit;
        if (Physics.Raycast(cameraAxis.position + new Vector3(0, 1, 0), ray, out hit, ray.magnitude))
        {

            transform.position = hit.point;
        }
        else
        {
            transform.position = transform.parent.position;
        }
    }
}
