using UnityEngine;

public class FormChanger : MonoBehaviour
{
    public Transform firstForm;
    public Transform lastForm;

    public Material firstFormMaterial;
    public Material lastFormMaterial;
    public Material formChangerMaterial;

    [Range(0, 1)]public float lerpValue;

    void Update()
    {
        transform.position = Vector3.Lerp(firstForm.position, lastForm.position, lerpValue);
        transform.rotation = Quaternion.Lerp(firstForm.rotation, lastForm.rotation, lerpValue);
        transform.localScale = Vector3.Lerp(firstForm.localScale, lastForm.localScale, lerpValue);
        formChangerMaterial.color = Color.Lerp(firstFormMaterial.color, lastFormMaterial.color, lerpValue);
    }
}
