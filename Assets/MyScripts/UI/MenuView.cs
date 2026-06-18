using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using Unity.VisualScripting;

public class MenuView : MonoBehaviour
{
    [SerializeField] public SpriteRenderer BackgroundImage;
    [SerializeField] public AudioClip MenuSound;
    [SerializeField] public AudioSource Source;
    [SerializeField] public Button PlayButton;
    [SerializeField] public Button ExitButton;

    [Header("Color Animation Settings")]
    [SerializeField] private float speed = 0.5f; // скорость смены цвета

    private float t = 0f;

    private void Start()
    {
        if (Source && MenuSound)
        {
            Source.clip = MenuSound;
            Source.loop = true;
            Source.Play();
        }
    }

    private void Update()
    {
        if (BackgroundImage != null)
        {
            t += Time.deltaTime * speed;
            float pingPong = Mathf.PingPong(t, 1f);

            Color color = BackgroundImage.color;
            color.a = Mathf.Lerp(1.0f, 0.95f, pingPong);
            BackgroundImage.color = color;
        }
    }

    public void OnPlayButtonPressed()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExitButtonPressed()
    {
        Application.Quit();
        Debug.Log("OnExitButtonPressed");
    }
}
