using UnityEngine;

public class PauseController : MonoBehaviour
{
    public AudioSource sound;

    private bool paused;

    public void PauseGame()
    {
        if(paused)
        {
            Time.timeScale = 1;
            sound.Play();
        }
        else
        {
            Time.timeScale = 0;
            sound.Pause();
        }

        paused = !paused;
    }

}
