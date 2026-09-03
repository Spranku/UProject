using UnityEngine;
using System.Collections;

public class ExplosionBarrell : MonoBehaviour 
{
    public ParticleSystem ExplosionVFX;
    private CircleCollider2D CircleZone;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CircleZone = GetComponent<CircleCollider2D>();
        if (CircleZone != null)
        {
            CircleZone.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CircleZone.enabled = true;
        Coroutine myCoroutine = StartCoroutine(Timer(0.5f));
        /* Hide sprite with explosion */
        var mySprite = GetComponent<SpriteRenderer>();
        mySprite.enabled = false;

        /* Launch VFX */
        ExplosionVFX.Play();
    }

    private IEnumerator Timer(float Time)
    {
        yield return new WaitForSeconds(Time);
        DestroyObject();
    }

    private void DestroyObject()
    {
        CircleZone.enabled = false;
        gameObject.SetActive(false);
    }
}
