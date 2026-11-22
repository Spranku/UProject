using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrazyRunWinLose : MonoBehaviour
{
    [SerializeField]
    public Button restartNextButton;
    [SerializeField]
    public Button menuButton;
    [SerializeField]
    public Text buttonText;
    [SerializeField]
    public Text winLoseText;

    /* Dirty flag pattern :) */
    bool bIsWon = false;

    public void SetGameResult(bool bWon)
    {
        bIsWon = bWon;
        if(bIsWon)
        {

            winLoseText.text = "You are won!";
            buttonText.text = "Next level";
            Debug.Log("Won");
        }
        else
        {
            winLoseText.text = "Fail!";
            buttonText.text = "Try again";
            Debug.Log("Loose");
        }
    }

    public void OnRestartNextButtonClicked()
    {
        if(bIsWon)
        {
            int nextLevelIndex = SceneManager.GetActiveScene().buildIndex + 1;
            if(nextLevelIndex != 3)
            {
                SceneManager.LoadScene(nextLevelIndex);
            }
            else
            {
                /* Return to first level */
                SceneManager.LoadScene(1);
                buttonText.text = "Return to menu";
            }
        }
        else 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void OnMenuClicked()
    {
        SceneManager.LoadScene(0);
    }
}

