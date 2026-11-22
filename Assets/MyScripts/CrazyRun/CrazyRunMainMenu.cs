using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CrazyRunMainMenu : MonoBehaviour
{
    [SerializeField]
    public Button playButton;
    [SerializeField]
    public Button aboutButton;
    [SerializeField]
    public Button menuButton;
    [SerializeField]
    public GameObject aboutPanel;

    public void OnPlayClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnAboutClicked()
    {
        if(aboutPanel)
        {
            aboutPanel.SetActive(true);
        }
    }

    public void OnMenuClicked()
    {
        if (aboutPanel) { aboutPanel.SetActive(false); }

        SceneManager.LoadScene(0);
    }
}
