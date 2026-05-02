using System.Collections;
using UnityEngine;

public class VFXComponent : MonoBehaviour
{
    /* Type of launch particle system */
    public enum ActivationType
    {
        Duration,
        Infinite,
        Instant,
        Trigger
    }

    public ParticleSystem CurrentParticleSystem = null;
    public ActivationType CurrentActivationType;
    public GameObject TriggerObject = null;
    public float DurationTime = 0.0f;

    void Start()
    {
        var MainSettings = CurrentParticleSystem.main;
        switch (CurrentActivationType)
        {
            case ActivationType.Duration:
                {
                    MainSettings.duration = DurationTime;
                    MainSettings.loop = false;
                    Coroutine coroutine = StartCoroutine(Timer(DurationTime));
                }
                break;
            case ActivationType.Infinite:
                {
                    MainSettings.loop = true;
                    LaunchVFX();
                }
                break;
            case ActivationType.Instant:
                {
                    MainSettings.duration = 0.1f;
                    MainSettings.loop = false;
                    LaunchVFX();
                }
                break;
            default:
                break;
        }
    }

    /* Lauch by trigger*/
    private void OnTriggerEnter(Collider other)
    {
        if (CurrentActivationType == ActivationType.Trigger && TriggerObject != null)
        {
            LaunchVFX();
        }
    }

    /* Launch by duration */
    private IEnumerator Timer(float Time)
    {
        yield return new WaitForSeconds(Time);
        LaunchVFX();    
    }

    private void LaunchVFX()
    {
        if (!CurrentParticleSystem) return;
        CurrentParticleSystem.Play();
    }
}
