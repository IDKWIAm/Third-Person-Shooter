using System.Numerics;
using UnityEngine;

public class FindCenter : MonoBehaviour
{
    public Transform pointA;
    public Transform pointB;
    void Update()
    {
        transform.position = (pointA.position + pointB.position) / 2;
    }
}
