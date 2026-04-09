using UnityEngine;

public class GravitySphere : MonoBehaviour
{
    private float SourceMass;
    private bool CanMove = true;
    Rigidbody rb;
    Vector3 Direction = new Vector3(6.0f, 5, -3);

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        var rb = other.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.mass = 0.0f;
        SourceMass = rb.mass;
    }

    private void OnTriggerExit(Collider other)
    {
        var rb = other.gameObject.GetComponent<Rigidbody>();
        rb.useGravity = true;
        rb.mass = SourceMass;
    }
}
