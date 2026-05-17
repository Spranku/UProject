using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected GameObject TargetObjectToAttack = null;
    private bool bCanAttack = false;
    private Coroutine attackCoroutine;


    protected virtual void Start() {}

    protected virtual void OnTriggerEnter2D(Collider2D collision) 
    {
        if (TargetObjectToAttack != null && collision.CompareTag("Player"))
        {
            bCanAttack = true;

            /* Damage timer */
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(DamageOverTime());
            }

            /* Anim & VFX*/
            Attack();
        }
    }

    protected virtual IEnumerator DamageOverTime()
    {
        while (bCanAttack)
        {
            if (TargetObjectToAttack != null)
            {
                var HealthComp = TargetObjectToAttack.GetComponent<HealthComponent>();
                if (HealthComp != null)
                {
                    HealthComp.TakeDamage(10);
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision) 
    {
        if (collision.gameObject != TargetObjectToAttack)
        {
            bCanAttack = false;

            Wait();

            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
        }
    }

    protected virtual void Attack() {}

    protected virtual void Wait() {}

    protected virtual void Death() {}
}
