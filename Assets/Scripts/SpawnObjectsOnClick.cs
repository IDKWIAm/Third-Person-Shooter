using UnityEngine;

public class SpawnObjectsOnClick : MonoBehaviour
{
    public GameObject instance;

    public Camera cameraLink;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            var ray = cameraLink.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Instantiate(instance, hit.point, Quaternion.identity);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            var ray = cameraLink.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Instance"))
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
