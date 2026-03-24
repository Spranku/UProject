using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public TMP_Text timerText;
    private float currentTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        currentTime = Mathf.Round(Time.time);
        timerText.text = currentTime.ToString();
    }
}
