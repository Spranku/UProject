using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool IsLastLevel = false;
    public Canvas WinnerCanvas = null;
    public GameObject WinnerVFX = null;

    private void Start()
    {
        WinnerCanvas.gameObject.SetActive(false);
    }

    public void OnShowWinnerScreen()
    {
        if(WinnerCanvas)
        {
            WinnerCanvas.gameObject.SetActive(true);
            if(WinnerVFX)
            {
                var Particles = WinnerVFX.GetComponentsInChildren<ParticleSystem>();
                for(byte i = 0; i < Particles.Length; ++i)
                {
                    Particles[i].Play();
                }
            }
            Coroutine coroutine = StartCoroutine(ReturnToMainMenuTimer());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController") && !IsLastLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.CompareTag("GameController") && IsLastLevel)
        {
            OnShowWinnerScreen();
        }
    }

    private IEnumerator ReturnToMainMenuTimer()
    {
        yield return new WaitForSeconds(3.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
    }
}
