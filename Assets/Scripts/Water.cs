using UnityEngine;

public class Water : MonoBehaviour
{
    public float force = 1f;
    public float drag = 1f;
    public float angularDrag = 1f;

    private void OnTriggerStay(Collider col)
    {
        var rigitbody = col.gameObject.GetComponent<Rigidbody>();
        
        var top = transform.localPosition.y + transform.localScale.y / 2;
        var lerpValue = Mathf.Lerp(top + col.transform.localScale.y / 2, top, Mathf.Clamp(col.transform.localPosition.y, 0, 1));
        var locForce = Mathf.Lerp(0, force, lerpValue);
        rigitbody.drag = Mathf.Lerp(0, drag, lerpValue);
        rigitbody.angularDrag = Mathf.Lerp(0.05f, angularDrag, lerpValue);
        rigitbody.AddForce(Vector3.up * locForce);
    }
}
