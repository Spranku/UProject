using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected Animator EnemyAnimator;
    [SerializeField] protected float Speed = 3.0f;
    [SerializeField] protected float IdleTime = 2.0f; 
    [SerializeField] protected SpriteRenderer EnemySprite;

    private bool bCanAttack = false;
    private Coroutine attackCoroutine;
    public GameObject currentTarget = null;
    private float idleTimer = 0f;
    private bool isIdle = false;
    private float currentDirection = 1f; 


    private const int IDLE_STATE = 0;
    private const int WALK_STATE = 1;
    private const int ATTACK_STATE = 2;

    private int currentState = WALK_STATE;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentDirection = 1f;
    }

    protected void Update()
    {
        /* Launch timer if enemy is idle */
        if (currentState == IDLE_STATE)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= IdleTime)
            {
                currentState = WALK_STATE;
                idleTimer = 0f;
                isIdle = false;
            }
        }

        /* Handle state */
        switch (currentState)
        {
            case IDLE_STATE:
                rb.linearVelocity = Vector2.zero;
                break;

            case WALK_STATE:
                rb.linearVelocity = new Vector2(currentDirection * Speed, rb.linearVelocity.y);
                break;

            case ATTACK_STATE:
                if (currentTarget != null)
                {
                    /* Move to player */
                    Vector2 direction = (currentTarget.transform.position - transform.position).normalized;
                    rb.linearVelocity = new Vector2(direction.x * Speed/* * 1.5f*/, rb.linearVelocity.y);

                    /* Rotate to player */
                    if (direction.x > 0 && EnemySprite.flipX)
                        EnemySprite.flipX = false;
                    else if (direction.x < 0 && !EnemySprite.flipX)
                        EnemySprite.flipX = true;
                }
                break;
        }
        /* Animations */
        EnemyAnimator.SetFloat("Velocity", rb.linearVelocity.magnitude);
    }

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        /* Enter trigger */
        if (collision.CompareTag("Player"))
        {
            currentTarget = collision.gameObject;
            currentState = ATTACK_STATE;
            bCanAttack = true;


            /* Launch damage coroutine */
            if (attackCoroutine == null)
            {
                attackCoroutine = StartCoroutine(DamageOverTime());
            }

            /* Attack animation */
            Attack();
        }

        /* Wall hit*/
        else if (collision.CompareTag("Wall") && currentState != ATTACK_STATE)
        {
            /* Rotate */
            currentDirection *= -1;
            EnemySprite.flipX = !EnemySprite.flipX;

            /* To idle */
            currentState = IDLE_STATE;
            idleTimer = 0f;
            isIdle = true;

        }
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        /* Player out attack trigger */
        if (collision.CompareTag("Player") && collision.gameObject == currentTarget)
        {
            bCanAttack = false;
            currentTarget = null;
            currentState = WALK_STATE; /* Return to patrol */

            /* Remove damage coroutine */
            if (attackCoroutine != null)
            {
                StopCoroutine(attackCoroutine);
                attackCoroutine = null;
            }
            Wait();
        }
    }

    protected virtual IEnumerator DamageOverTime()
    {
        while (bCanAttack && currentTarget != null)
        {
            var HealthComp = currentTarget.GetComponentInParent<HealthComponent>();
            if (HealthComp != null)
            {
                HealthComp.TakeDamage(10);
                Debug.Log("DAMAGE DEALT: 10");
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    protected virtual void Attack() { }
   
    protected virtual void Wait() { }

    protected virtual void Death() { }
}
