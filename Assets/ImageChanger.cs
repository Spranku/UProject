using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    public Sprite newSprite;

    private Image img;

    public AudioClip Clip;

    private AudioSource audio;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
        audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void ChangeSound()
    {
        audio.clip = Clip;
    }

    public void ChangeSoundPlay()
    {
        if(audio.isPlaying)
        {
            audio.Pause();
        }
        else
        {
            audio.Play();
        }
    }

    public void ChangeSprite()
    {
        img.sprite = newSprite;
        img.SetNativeSize();
    }

    public void ChangeColor()
    {
        //img.color = Color.magenta;
        img.color = new Color(0.1f, 0.2f, 0.3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
