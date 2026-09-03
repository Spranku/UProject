using UnityEngine;


public class SoftLaunchPlatform : LaunchPlatform
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if(other.CompareTag("GameController"))
        {
            Launch();
        }
    }

    protected override void Update() {}

    protected override void Launch()
    {
        rg.AddForce(new Vector3(transform.position.x, transform.position.y - (-0.01f) * LauchPower, transform.position.z), ForceMode.Impulse);
        if (JumpSound && MainAudioSource)
        { 
            MainAudioSource.PlayOneShot(JumpSound);
        }

            rg = null;
    }
}
