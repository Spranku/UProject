using UnityEngine;
using WildBall.Inputs;

[RequireComponent(typeof(PlayerMovement))]
public class PF_PlayerInput : PlayerInput
{
    public override void Awake()
    {
        base.Awake();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        float horizontalDirection = Input.GetAxisRaw(GlobalStringVars.HORIZONTAL_AXIS);
        bool isJumpButtonPressed = Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON);
        //
        //

        playerMovement.Move(horizontalDirection, isJumpButtonPressed);
    }
}
