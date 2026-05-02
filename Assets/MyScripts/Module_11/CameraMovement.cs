using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform PlayerTransform;

    private Vector3 Offset;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Offset = transform.position - PlayerTransform.position;
    }

    private void FixedUpdate()
    {
        transform.position = PlayerTransform.position + Offset;
    }
}
