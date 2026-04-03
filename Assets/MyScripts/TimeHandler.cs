using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    /* Central numbers */
    public TMP_Text firstNum;
    public TMP_Text secondNum;
    public TMP_Text thirdNum;

    /* Loose/Win text*/
    public TMP_Text losewinText;

    /* Tools buttons */
    public Button drillButton;
    public Button hammerButton;
    public Button pickButton;

    /* Lose/Win widget */
    public GameObject LoseWinWidget;

    /* Timer variables */
    //public TMP_Text timerText;
    private float currentTime;
    private float currentTimer;
    private bool isTimerRun = false;
    public TMP_Text CurrentTimerText;
    public float timerSec = 60.0f;

    /* Main vectors */
    private Vector3 SourceVec = new Vector3(0,0,0);
    public Vector3 PinsVector = new Vector3 (7, 3, 5);
    public Vector3 VectotToWin = new Vector3(0,0,0);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ///SendFinalResult(false);
        StartTimer(timerSec);

        /* First init */
       InitializePins(PinsVector);
    }

    private void InitializePins(Vector3 VectorToInit)
    {
        PinsVector = VectorToInit;
        SourceVec = PinsVector;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTimerRun)
        {
            currentTimer -= Time.deltaTime;

            if(currentTimer <=0)
            {
                currentTimer = 0;
                isTimerRun = false;
                SendFinalResult(false);
            }
            CurrentTimerText.text = Mathf.RoundToInt(currentTimer).ToString();

            /* Lazy update */
            firstNum.text = PinsVector.x.ToString();
            secondNum.text = PinsVector.y.ToString();
            thirdNum.text = PinsVector.z.ToString();    
        }

    }

    public void CheckWin(Vector3 VectorToCheck)
    {
        if(VectorToCheck == VectotToWin)
        {
            isTimerRun = false;
            SendFinalResult (true);
        }
    }

    private void StartTimer(float TimerTime)
    {
        currentTimer = TimerTime;
        isTimerRun = true;
    }

    public void SendFinalResult(bool bIsWin)
    {
        if (!LoseWinWidget) return;

        if (bIsWin)
        {
            losewinText.text = "You are win!";
        }
        else
        {
            losewinText.text = "You are lose!";
        }

        LoseWinWidget.SetActive(true);   
    }

    public void RestartGame()
    {
        if (!LoseWinWidget) return;

        LoseWinWidget.SetActive(false);

        /* New game setup*/
        InitializePins(SourceVec);
        Start();
    }

    public void OnDrillButtonClick()
    {
        if (drillButton == null) return;

        if(PinsVector.x <= 9)
        {
            PinsVector.x += 1;
        }

        if (PinsVector.y > 0)
        {
            PinsVector.y -= 1;
        }
        
        /* Do nothing */

         CheckWin(PinsVector);
    }

    public void OnHammerButtonClick()
    {
        if (hammerButton == null) return;

        if (PinsVector.x > 0)
        {
            PinsVector.x -= 1;
        }

        if (PinsVector.y <= 8 )
        {
            PinsVector.y += 2; 
        }

        if(PinsVector.z > 0)
        {
            PinsVector.z -= 1;
        }

        CheckWin(PinsVector);
    }

    public void OnPickButtonClick()
    {
        if (pickButton == null) return;

        if (PinsVector.x > 0)
        {
            PinsVector.x -= 1;
        }

        if (PinsVector.y <= 9)
        {
            PinsVector.y += 1;
        }

        if (PinsVector.z <= 9)
        {
            PinsVector.z += 1;
        }

        CheckWin(PinsVector);
    }

}
