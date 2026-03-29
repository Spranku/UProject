using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button StartGameButton;
    public Button LeaveGameButton;
    public string gameSceneName = "Level1_SaveTheVillage";

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Game closed success");
    }
}
