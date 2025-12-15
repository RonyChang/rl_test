using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    void Awake()
    {

    }

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
