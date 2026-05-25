using UnityEngine;
using System.Collections;
using UnityEngine.TextCore.Text;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator EnemyAnimator;
    [SerializeField] protected float Speed = 3.0f;
    [SerializeField] protected float TimeToRevert = 3.0f;
    [SerializeField] protected GameObject TargetObjectToAttack = null;
    [SerializeField] protected SpriteRenderer EnemySprite;
    private bool bCanAttack = false;
    private Coroutine attackCoroutine;

    private const float IDLE_STATE = 0;
    private const float WALK_STATE = 1;
    private const float REVERT_STATE = 2;

    private float currentState, currentTimeToRevert;

    protected virtual void Start() 
    {
        currentState = WALK_STATE;
        currentTimeToRevert = 0;
        rb = GetComponent<Rigidbody2D>();
    }

    protected void Update()
    {
        if (currentTimeToRevert >= TimeToRevert)
        {
            currentTimeToRevert = 0;
            currentState = REVERT_STATE;
        }


        switch (currentState)
        {
            case IDLE_STATE:
                currentTimeToRevert += Time.deltaTime;
              
                break;
            case WALK_STATE:
                rb.linearVelocity = Vector2.right * Speed;
                break;
            case REVERT_STATE:
                EnemySprite.flipX = !EnemySprite.flipX;
                Speed *= -1;
                currentState = WALK_STATE;
                break;
            default:
                break;
        }

        EnemyAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);
    }

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

            SpriteRenderer TargetSprite = TargetObjectToAttack.GetComponent<SpriteRenderer>();
            if(TargetSprite)
            { 
                if(TargetSprite.flipX && !EnemySprite.flipX)
                {
                    currentState = REVERT_STATE;
                }

            }

            /* Anim & VFX*/
            Attack();
        }
        else if(collision.CompareTag("Wall"))
        {
            currentState = IDLE_STATE;
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
