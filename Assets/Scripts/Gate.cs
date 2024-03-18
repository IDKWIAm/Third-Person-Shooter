using UnityEngine;

public class Gate : MonoBehaviour
{
    public float yRotateGate1;
    public float yRotateGate2;

    public void Open()
    {
        transform.GetChild(0).Rotate(0, yRotateGate1, 0);
        transform.GetChild(1).Rotate(0, yRotateGate2, 0);
    }
}
