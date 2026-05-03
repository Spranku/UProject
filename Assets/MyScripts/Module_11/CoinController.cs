using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinController : MonoBehaviour
{
    public AudioSource MainAudioSource;
    public AudioClip PickUpSound;
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Anim.SetBool("Alive", false);
        Anim.SetTrigger("Collect");
        if (MainAudioSource) MainAudioSource.PlayOneShot(PickUpSound);
        Destroy(gameObject, 0.5f);
    }
}
