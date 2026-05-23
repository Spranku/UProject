using UnityEngine;
using System.Collections;

public class DarkEnemyController : EnemyController
{
    
    public ParticleSystem EnemyAttackVFX = null;
    private HealthComponent EnemyHealthComp;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        EnemyHealthComp = GetComponent<HealthComponent>();

        /* Subscribe OnDeath event */
        if (EnemyHealthComp != null)
        {
            EnemyHealthComp.OnDeath += HandleDeath;
        }
        Wait();
    }

    private void HandleDeath()
    {
        Death();
    }

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);
    }

    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
    }

    protected override void Attack() 
    {
        EnemyAnimator.SetBool("IsIdle", false);
        EnemyAnimator.SetBool("IsAttack", true);

        /* Launch attack VFX */
        if (EnemyAttackVFX != null)
        {
            EnemyAttackVFX.Clear();
            EnemyAttackVFX.Play();
        }
    }

    protected override void Wait() 
    {
        EnemyAnimator.SetBool("IsAttack", false);
        EnemyAnimator.SetBool("IsIdle", true);

        /* Remove attack VFX */
        if (EnemyAttackVFX != null)
        {
            EnemyAttackVFX.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        }
    }

    protected override void Death() 
    {
        /* Change anim state */
        EnemyAnimator.SetBool("IsDeath", true);

        /* Disble VFX */
        if (EnemyAttackVFX != null)
        {
            EnemyAttackVFX.Stop();
        }

        /* Disable collision after death */
        var DeathCollision = gameObject.GetComponent<BoxCollider2D>();
        if (DeathCollision != null) DeathCollision.enabled = false;

        /* Timer to delete object */
        var DeathCoroutine = StartCoroutine(DestroyTimer());
    }

    private IEnumerator DestroyTimer()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
}
