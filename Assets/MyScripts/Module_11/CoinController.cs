using System;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CoinController : MonoBehaviour
{
    public AudioSource MainAudioSource;
    public AudioClip PickUpSound;
    public byte Cost = 1;
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            /* Send cost of coin */
            var InventoryComponent = collision.gameObject.GetComponentInParent<InventoryComp>();
            if(InventoryComponent != null)
            {
                InventoryComponent.AddScore(Cost);
            }

            /* Lauch VFX & sound */
            Anim.SetBool("Alive", false);
            Anim.SetTrigger("Collect");
            if (MainAudioSource) MainAudioSource.PlayOneShot(PickUpSound);
            Destroy(gameObject, 0.5f);
        }
    }
}
