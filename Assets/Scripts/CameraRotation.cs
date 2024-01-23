using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;

    public float RotationSpeed = 50f;

    public float minAngle;
    public float maxAngle;

    void Start()
    {
        
    }

    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + RotationSpeed * Time.deltaTime * Input.GetAxis("Mouse X"), 0);

        var newAngleX = CameraAxisTransform.localEulerAngles.x - RotationSpeed * Time.deltaTime * Input.GetAxis("Mouse Y");
        if (newAngleX > 180)
            newAngleX -= 360;

        newAngleX = Mathf.Clamp(newAngleX, minAngle, maxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(newAngleX, 0, 0);
    }
}
