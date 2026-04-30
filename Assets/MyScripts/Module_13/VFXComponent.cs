using UnityEngine;

public class VFXComponent : MonoBehaviour
{
    /* Type of laucnh particle system */
    public enum ActivationType
    {
        Duration,
        Infinite,
        Instant
    }

    public ParticleSystem MyParticleSystem;
    public float DurationTime = 0.0f;
    public ActivationType CurrentType;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ///MyParticleSystem = GetComponent<ParticleSystem>();
        var MainSettings = MyParticleSystem.main;
        switch (CurrentType)
        {
            case ActivationType.Duration:
                MainSettings.duration = DurationTime;
                MainSettings.loop = false;
                break;
            case ActivationType.Infinite:
                MainSettings.loop = true;
                break;
            case ActivationType.Instant:
                MainSettings.duration = 0.1f;
                MainSettings.loop = false;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            if (!MyParticleSystem) return;
            MyParticleSystem.Play();
        }
    }
}
