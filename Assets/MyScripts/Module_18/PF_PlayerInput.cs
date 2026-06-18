using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(ShooterComponent))]
public class PF_PlayerInput : PlayerInput
{
    private ShooterComponent ShooterComp;

    public override void Awake()
    {
        base.Awake();
        ShooterComp = GetComponent<ShooterComponent>();
    }

    // Update is called once per frame
    public override void Update()
    {
        float horizontalDirection = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);

        if(Input.GetButtonDown(GlobalStringVars.FIRE_1))
        {
            ShooterComp.Shoot(horizontalDirection);
        }
        if(CanMove)
            playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
