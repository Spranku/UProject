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
    [SerializeField] private Transform GoundColliderTransform;
    [SerializeField] private float JumpOffset;
    [SerializeField] private LayerMask GroundMask;
    [SerializeField] private SpriteRenderer CharacterSprite;
    private Rigidbody2D rg2D;


    public override void Awake()
    {
        rg2D = GetComponent<Rigidbody2D>();
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
        if (Mathf.Abs(Direction) > 0.01f) HorizontalMovement(Direction);
    }

    private void Jump()
    {
        if (bIsOnGround) rg2D.linearVelocity = new Vector2(rg2D.linearVelocity.x, jumpForce);
    }

    private void HorizontalMovement(float Direction) 
    {
        if(Direction > 0.01f)
        {
            Debug.Log("Right");
            CharacterSprite.flipX = true;
        }

        if (Direction < 0.01f)
        {
            Debug.Log("Left");
            CharacterSprite.flipX = false;
        }

        rg2D.linearVelocity = new Vector2(Curve.Evaluate(Direction), rg2D.linearVelocity.y);
    }
}
