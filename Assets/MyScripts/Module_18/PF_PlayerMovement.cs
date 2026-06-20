using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(Rigidbody2D))]
public class PF_PlayerMovement : PlayerMovement
{
    [Header("Movement vars")]
    [SerializeField] private float jumpForce;
    [SerializeField] private bool bIsOnGround = false;

    [Header("Other settings")]
    [SerializeField] private AnimationCurve Curve;
    [SerializeField] private Animator CharacterAnimator;
    [SerializeField] private Transform GoundColliderTransform;
    [SerializeField] private float JumpOffset;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private SpriteRenderer CharacterSprite;
    private HealthComponent PlayerHealthComp;
    private Rigidbody2D rg2D;


    public override void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();

        PlayerHealthComp = GetComponent<HealthComponent>();

        /* Subscribe OnDeath event */
        if (PlayerHealthComp != null)
        {
            PlayerHealthComp.OnDeath += HandleDeath;
        }
    }

    private void HandleDeath()
    {
        Death();
    }

    private void Death()
    {
        CharacterAnimator.SetBool("IsDeath", true);
    }

    private void FixedUpdate()
    {
        Vector3 overlapCirclePosition = GoundColliderTransform.position;
        bIsOnGround = Physics2D.OverlapCircle(overlapCirclePosition, JumpOffset,GroundMask);
    }

    public override void Move(float Direction, bool bIsJumpButtonPressed)
    {
        /* Jump */
        if (bIsJumpButtonPressed) Jump();

        /* Horizontal movement */
        if (Mathf.Abs(Direction) > 0.01f)
        {
            /* Moving */
            HorizontalMovement(Direction);

            /* Lauch character walk animation */
            CharacterAnimator.SetBool("IsWalk", true);
        }
        else
        {
            CharacterAnimator.SetBool("IsWalk", false);
        }
    }

    private void Jump()
    {
        if (bIsOnGround) rg2D.linearVelocity = new Vector2(rg2D.linearVelocity.x, jumpForce);
    }

    private void HorizontalMovement(float Direction) 
    {
        /* Choice sprite direction */
        if(Direction > 0.01f) CharacterSprite.flipX = true;
        if (Direction < 0.01f) CharacterSprite.flipX = false;

        rg2D.linearVelocity = new Vector2(Curve.Evaluate(Direction), rg2D.linearVelocity.y);
    }
}
