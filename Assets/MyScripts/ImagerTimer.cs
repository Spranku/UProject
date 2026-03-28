using UnityEngine;
using UnityEngine.UI;

public class ImagerTimer : MonoBehaviour
{

    public float MaxTime;

    private Image img;
    private float currentTime;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        img = GetComponent<Image>();
        currentTime = MaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
            currentTime = MaxTime;

        img.fillAmount = currentTime / MaxTime;
    }
}
