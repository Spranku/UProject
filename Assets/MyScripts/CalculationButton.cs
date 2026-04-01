using System;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
//using UnityEditor.Actions;
using UnityEngine;
using UnityEngine.UI;

public class CalculationButton : MonoBehaviour
{
    public enum EAction
    {
        Addition,
        Substraction,
        Multiplication,
        Division,
        Compare
    }

    Button inButton;

    public TMP_InputField leftSide;
    public TMP_InputField rightSide;
    public TMP_Text Result;

    public void OnClick(Button inButton)
    {
        /* Save current sign of button */
        var buttonText = inButton.GetComponentInChildren<TMP_Text>();

        /* Choice func by sign */
        switch (buttonText.text)
        {
            case "+":
            {
                    TryToGiveResult(leftSide,rightSide,EAction.Addition);
                    break;
            }

            case "-":
            {
                    TryToGiveResult(leftSide, rightSide, EAction.Substraction);
                    break;
            }

            case "*":
            {
                    TryToGiveResult(leftSide, rightSide, EAction.Multiplication);
                    break; 
            }

            case "/":
            {
                    TryToGiveResult(leftSide, rightSide, EAction.Division);
                    break;
            }

            default:
                { break; }
        }
    }

    public bool CheckInput(TMP_InputField A, TMP_InputField B)
    {
        /* Check nullptr */
        if (A == null || B == null) return false;

        /*Check empty */
        if (A.text == "" || B.text == "") return false;

        /* Check convert to int */
        if (!int.TryParse(A.text, out _) || !int.TryParse(B.text, out _)) return false;

        return true;
    }

    protected void TryToGiveResult(TMP_InputField left, TMP_InputField right, EAction actionType)
    {
        if(!CheckInput(left, right)) return;

        switch (actionType)
        {
            case EAction.Addition:
                {
                    Addition(left,right);
                    break;
                }

            case EAction.Substraction:
                {
                    Substraction(left, right);
                    break;
                }

            case EAction.Multiplication:
                {
                    Multiplication(left,right);
                    break;
                }

            case EAction.Division:
                {
                    Division(left,right);
                    break;
                }

            case EAction.Compare:
                {
                    Compare(left, right);
                    break;
                }
        }
    }

    private void Addition(TMP_InputField A, TMP_InputField B)
    {
        int result = 0;

        if (int.TryParse(A.text, out int a) && int.TryParse(B.text, out int b))
        {
            result = a + b;
        }

        Result.text = result.ToString();
    }

    private void Substraction(TMP_InputField A, TMP_InputField B)
    {
        int result = 0;

        if (int.TryParse(A.text, out int a) && int.TryParse(B.text, out int b))
        {
            result = a - b;
        }

        Result.text = result.ToString();
    }

    private void Multiplication(TMP_InputField A, TMP_InputField B)
    {
        int result = 0;

        if (int.TryParse(A.text, out int a) && int.TryParse(B.text, out int b))
        {
            result = a * b;
        }

        Result.text = result.ToString();
    }

    private void Division(TMP_InputField A, TMP_InputField B)
    {
        int result = 0;

        if (int.TryParse(A.text, out int a) && int.TryParse(B.text, out int b))
        {
            result = a / b;
        }

        Result.text = result.ToString();
    }

    private void Compare(TMP_InputField A, TMP_InputField B)
    {
        int result = 0;

        if (int.TryParse(A.text, out int a) && int.TryParse(B.text, out int b))
        {
            result = a > b ? a : b;
        }

        Result.text = result.ToString();
    }
}
