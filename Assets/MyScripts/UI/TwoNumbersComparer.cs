using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TwoNumbersComparer : CalculationButton
{
    public void OnCompareClick()
    {
        base.TryToGiveResult(leftSide,rightSide,EAction.Compare);
    } 
}
