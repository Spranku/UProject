using UnityEngine;
using UnityEngine.UI;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] private int RandNum = 0;
    public Text text;
    public InputField inputField;

    private void Start()
    {
        RandNum = Random.Range(0, 101);
       
    }

    public void ReadText()
    {
        int result;
        if(inputField.text != "" && int.TryParse(inputField.text, out result))
        {
            text.text = result.ToString();
            Debug.Log(text.text);

            if(result == RandNum)
            {
                ShowMessage(true);
            }
            else
            {
                ShowMessage(false);
            }
        }
        else
        {
            Debug.Log("NewMonoBehaviourScript::ReadText - Error! Text is empty or failed parse");
        }
    }

    public void ShowMessage(bool bIsSuccess)
    {
        if (bIsSuccess)
        {
            text.text = "Yoy are right! The num is " + RandNum;
        }
        else 
        {
            text.text = "So sory! The num is different...";
            Debug.Log("RandNum = " + RandNum);
        }
    }
}
