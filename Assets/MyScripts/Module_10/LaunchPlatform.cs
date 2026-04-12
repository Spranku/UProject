using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class LaunchPlatform : MonoBehaviour
{
    public float LaunchPeriod = 1.0f;
    public float LauchPower = 100.0f;

    private float CachePeriod;
    Rigidbody rg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* Save source period for clear to default after launch */
        CachePeriod = LaunchPeriod;
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        LaunchPeriod -= Time.deltaTime;
        if (LaunchPeriod <= 0.0f)
        {
            Launch();
        }
    }

    private void Launch()
    {
        rg.AddForce(new Vector3(transform.position.x, transform.position.y - (-0.01f) * LauchPower, transform.position.z), ForceMode.Impulse);
        LaunchPeriod = CachePeriod;
    }
}
