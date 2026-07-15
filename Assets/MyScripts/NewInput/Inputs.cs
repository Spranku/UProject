using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public class Inputs : MonoBehaviour
{
    [SerializeField]
    public GameObject Character;
    [SerializeField] 
    public GameObject[] Weapons;
    [SerializeField]
    public TestHUD HUD;
    [SerializeField]
    public Animator CharacterAnimator;

    private int CurrentIndex = 0;
    private bool bIsSwapProcess = false;


    private void Start()
    {
        for(byte i = 0; i < Weapons.Length; ++i)
        {
            if(i <= 0)
            {
                Weapons[i].gameObject.SetActive(true);
            }
            else
            {
                Weapons[i].gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        if (scrollDelta > 0)
        {
            SwapWeapon(1);
        }
        else if (scrollDelta < 0)
        {
            SwapWeapon(-1);
        }
    }

    private void SwapWeapon(int Direction)
    {
        int newIndex = CurrentIndex + Direction;

        if (newIndex < 0)
            newIndex = Weapons.Length - 1;
        else if (newIndex >= Weapons.Length)
            newIndex = 0;

        Weapons[CurrentIndex].SetActive(false);
        Weapons[newIndex].SetActive(true);

        CurrentIndex = newIndex;
    }

    public void OnNum1(InputValue value)
    {
        CharacterAnimator.SetBool("Num1", true);
        if(HUD) { HUD.SetActiveElement(0); }
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum2(InputValue value)
    {
        CharacterAnimator.SetBool("Num2", true);
        if (HUD) { HUD.SetActiveElement(1); }
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum3(InputValue value)
    {
        CharacterAnimator.SetBool("Num3", true);
        if (HUD) { HUD.SetActiveElement(2); }
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num4", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum4(InputValue value)
    {
        CharacterAnimator.SetBool("Num4", true);
        if (HUD) { HUD.SetActiveElement(3); }
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num5", false);
    }

    public void OnNum5(InputValue value)
    {
        CharacterAnimator.SetBool("Num5", true);
        if (HUD) { HUD.SetActiveElement(4); }
        CharacterAnimator.SetBool("Num1", false);
        CharacterAnimator.SetBool("Num2", false);
        CharacterAnimator.SetBool("Num3", false);
        CharacterAnimator.SetBool("Num4", false);
    }

}
