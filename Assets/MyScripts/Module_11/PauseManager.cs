using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    public Image BackgroundImage;
    public GameObject HorizontalGroupMain;

    private void Start()
    {
        HorizontalGroupMain.SetActive(false);
        BackgroundImage.enabled = false;
    }

    public void OnPauseButton()
    {
        Time.timeScale = 0.0f;
        BackgroundImage.enabled = true;
        HorizontalGroupMain.SetActive(true);
    }


    public void OnContinueButton()
    {
        Time.timeScale = 1.0f;
        HorizontalGroupMain.SetActive(false);
        BackgroundImage.enabled = false;
    }

    public void OnMenuButton()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("WB_MainMenu");
    }
}
