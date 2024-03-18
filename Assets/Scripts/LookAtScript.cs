using UnityEngine;

public class LookAtScript : MonoBehaviour
{
    public Transform target;
    public float offsetX = 0f;
    public float offsetY = 0f;
    public float offsetZ = 0f;

    public float xAxisOffset = 0f;
    public float yAxisOffset = 0f;
    public float zAxisOffset = 0f;

    void Update()
    {
        transform.LookAt(target.position + new Vector3(offsetX, offsetY, offsetZ));
        transform.Rotate(xAxisOffset, yAxisOffset, zAxisOffset);
    }
}
