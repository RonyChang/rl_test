using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Awake()
    {

    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
