using UnityEngine;

public class BulletSource : MonoBehaviour
{
    public Transform targetPoint;
    public Camera cameraLink;
    public float targetInSkyDistance;
    public float minDistance;

    private void Update()
    {
        var ray = cameraLink.ViewportPointToRay(new Vector3(0.5f, 0.6f, 0));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.distance <= minDistance)
            {
                targetPoint.position = Camera.main.transform.position + ray.direction * minDistance * 2;
            }
            else
            {
                targetPoint.position = hit.point;
            }
        } 
        else
        {
            targetPoint.position = ray.GetPoint(targetInSkyDistance);
        }

        transform.LookAt(targetPoint.position);
    }
}
