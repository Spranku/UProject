using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class CylinderController : RampController
{
    /* Inherit */

    public AudioSource MainAudioSource;
    public AudioClip DeathSound;

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            var myMesh = other.GetComponent<MeshRenderer>();
            if (myMesh) myMesh.forceRenderingOff = true;

            var OtherParticleSystem = other.gameObject.GetComponent<ParticleSystem>();
            if(OtherParticleSystem) OtherParticleSystem.Play();
            if (MainAudioSource) MainAudioSource.PlayOneShot(DeathSound);
            Coroutine coroutine = StartCoroutine(DeathTimer());
        }
    }

    private IEnumerator DeathTimer()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
