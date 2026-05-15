using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(Rigidbody2D))]
public class PF_PlayerMovement : PlayerMovement
{
    [SerializeField] private float jumpForce;
    [SerializeField] private bool bIsOnGround = false;
    [SerializeField] private Transform GoundColliderTransform;
    [SerializeField] private float JumpOffset;
    [SerializeField] private LayerMask GroundMask;
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
        if (bIsJumpButtonPressed)
        {
            Jump();
        }
        // Horizontal movement
    }

    private void Jump()
    {
        if (bIsOnGround) rg2D.linearVelocity = new Vector2(rg2D.linearVelocity.x, jumpForce);
    }
}
