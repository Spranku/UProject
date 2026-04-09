using UnityEngine;

public class BilliardBall : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 LaunchVector = new Vector3(transform.position.x,
                                           transform.position.y,
                                           transform.position.z * (-2));

        rb.AddForce(LaunchVector, ForceMode.Impulse);
    }

}
