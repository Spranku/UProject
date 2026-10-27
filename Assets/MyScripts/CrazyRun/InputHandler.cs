using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public bool IsThereTouchOnScreen()
    {
        if (Input.touchCount > 0)
        {
            return true;
        }
        return false;
    }

    public Vector2 GetTouchDeltaPosition()
    {
        if(Input.touchCount > 0)
        {
            return Input. GetTouch(0).position;
        }
        return Vector2.zero;
    }

    private void Update()
    {
        Debug.Log(IsThereTouchOnScreen() + " touch on screen");
    }
}
