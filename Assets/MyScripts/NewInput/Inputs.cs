using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;

    [SerializeField]
    public TestHUD HUD;

    [SerializeField]
    public Animator CharacterAnimator;

    public void OnNum1(InputValue value)
    {
        CharacterAnimator.SetBool("Num1", true);
        if(HUD) { HUD.SetActiveElement(0); }
        Debug.Log("Num1");
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum2(InputValue value)
    {
        CharacterAnimator.SetBool("Num2", true);
        if (HUD) { HUD.SetActiveElement(1); }
        Debug.Log("Num2 ");
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum3(InputValue value)
    {
        CharacterAnimator.SetBool("Num3", true);
        if (HUD) { HUD.SetActiveElement(2); }
        Debug.Log("Num3");
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum4(InputValue value)
    {
        CharacterAnimator.SetBool("Num4", true);
        if (HUD) { HUD.SetActiveElement(3); }
        Debug.Log("Num4");
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum5(InputValue value)
    {
        CharacterAnimator.SetBool("Num5", true);
        if (HUD) { HUD.SetActiveElement(4); }
        Debug.Log("Num5");
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
    }
}
