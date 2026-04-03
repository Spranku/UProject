using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public AudioClip buttonClickSound;
    public AudioClip menuSound;
    public AudioSource audioSource;

    public Button StartGameButton;
    public Button LeaveGameButton;
    public string gameSceneName = "Level1_SaveTheVillage";

    void Start()
    {
        /* Launch ambient */
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = menuSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Game closed success");
    }

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
