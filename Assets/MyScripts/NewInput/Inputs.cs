using UnityEngine;
using UnityEngine.InputSystem;

public class Inputs : MonoBehaviour
{
    public bool Num1;
    public bool Num2;
    public bool Num3;
    public bool Num4;
    public bool Num5;

    public void OnNum1(InputValue value)
    {
        Debug.Log("Num1");
    }

    public void OnNum2(InputValue value)
    {
        Debug.Log("Num2 ");
    }

    public void OnNum3(InputValue value)
    {
        Debug.Log("Num3");
    }

    public void OnNum4(InputValue value)
    {
        Debug.Log("Num4");
    }

    public void OnNum5(InputValue value)
    {
        Debug.Log("Num5");
    }
}
