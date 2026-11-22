using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CrazyRunTimer : MonoBehaviour
{
    [SerializeField]
    public float minutes = 0f;
    [SerializeField]
    public float seconds = 0f;
    [SerializeField]
    public Text timerText;
    [SerializeField]
    public CrazyRunWinLose winLose;

    private float currentTimeInSeconds;
    private bool isTimerRunning = false;
    private Coroutine timerCoroutine;

    public string TimeString { get; private set; }

    void Start()
    {
        currentTimeInSeconds = (minutes * 60f) + seconds;
        StartTimer();
    }

    public void StartTimer()
    {
        if (timerCoroutine != null) StopCoroutine(timerCoroutine);
        isTimerRunning = true;
        timerCoroutine = StartCoroutine(TimerRoutine());
    }

    public void StopTimer()
    {
        isTimerRunning = false;
    }

    private IEnumerator TimerRoutine()
    {
        while (isTimerRunning && currentTimeInSeconds > 0)
        {
            UpdateUI(); 

            yield return new WaitForSeconds(1f);

            if (!isTimerRunning) yield break; 

            currentTimeInSeconds--;
        }

        currentTimeInSeconds = 0;
        UpdateUI();
        isTimerRunning = false;
        OnTimerEnd();
    }

    private void UpdateUI()
    {
        int displayMinutes = Mathf.FloorToInt(currentTimeInSeconds / 60f);
        int displaySeconds = Mathf.FloorToInt(currentTimeInSeconds % 60f);

        TimeString = string.Format("{0:00}:{1:00}", displayMinutes, displaySeconds);

        if (timerText != null)
        {
            timerText.text = TimeString;
        }
    }

    private void OnTimerEnd()
    {
        if (winLose)
        {
            winLose.gameObject.SetActive(true);
            winLose.SetGameResult(false);
        }
    }
}
