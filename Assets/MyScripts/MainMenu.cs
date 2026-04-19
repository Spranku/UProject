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

    public virtual void Start()
    {
        /* Launch ambient */
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = menuSound;
        audioSource.loop = true;
        audioSource.Play();
    }

    public virtual void StartGame()
    {
        Debug.Log("Super::StargMae-");
        SceneManager.LoadScene(gameSceneName);
    }

    public virtual void LeaveGame()
    {
        Application.Quit();
        Debug.Log("Game closed success");
    }

    public virtual void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }
}
