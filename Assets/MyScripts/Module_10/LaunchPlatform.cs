using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(AudioSource))]
public class LaunchPlatform : MonoBehaviour
{
    [SerializeField] public float LaunchPeriod = 1.0f;
    [SerializeField] public float LauchPower = 100.0f;
    public AudioSource MainAudioSource;
    public AudioClip JumpSound;

    private float CachePeriod;
    protected Rigidbody rg;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected virtual void Start()
    {
        /* Save source period for clear to default after launch */
        CachePeriod = LaunchPeriod;
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        LaunchPeriod -= Time.deltaTime;
        if (LaunchPeriod <= 0.0f)
        {
            Launch();
        }
    }

    protected virtual void Launch()
    {
        rg.AddForce(new Vector3(transform.position.x, transform.position.y - (-0.01f) * LauchPower, transform.position.z), ForceMode.Impulse);
        LaunchPeriod = CachePeriod;
    }
}
