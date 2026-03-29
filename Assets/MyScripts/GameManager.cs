using TMPro;
using Unity.VisualScripting;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public ImagerTimer HarvestTimer;
    public ImagerTimer FoodTimer;

    public GameObject GameOverScreen;

    /* UI Images */
    public Image PeopleTimerImg;
    public Image WarriorTimerImg;
    public Image RaidTimerImg;

    /* Count of resources */
    public int peopleCount;
    public int warriorCount;
    public int breadCount;

    /* Buttons */
    public Button hirePersonButton;
    public Button hireWarrionButton;
    public Button retryGame;

    /*  */
    public int minedBreadPeople;
    public int consumptionBreadWarrior;
    public int peopleCost;
    public int warriorCost;

    /* Text variables */
    public TMP_Text resourcePeople;
    public TMP_Text resourceWarrior;
    public TMP_Text resourceBread;
    public TMP_Text countEnemiesSoon;
    public TMP_Text countSafeCycles;
    /* For final stats */
    public TMP_Text raidsSurvived;
    public TMP_Text producedBread;
    public TMP_Text peopleSurvived;
    public TMP_Text warriorSurvived;

    public float peopleCreateTime;
    public float warriorCreateTime;
    public float maxTimeBeforeNexRaid;
    public int countEnemyWarriors;
    public int countSafeRounds;
    public int nextRaid;

    /* Final stats variables */
    private int countSurivedRaids;

    /* Timer variables */
    private float peopleTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;

    private bool createPeoplePressed;
    private bool createWarriorPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        GameOverScreen.SetActive(false);

        /* Clear stats */
        countSurivedRaids = 0;

        /* Pre init count of enemies for next raid */
        nextRaid += countEnemyWarriors;

        UpdateResourceText();
        raidTimer = maxTimeBeforeNexRaid;
    }

    // Update is called once per frame
    void Update()
    {
        /* Launch raid timer only if has`nt safe rounds */
        if (countSafeRounds == 0)
        {
            raidTimer -= Time.deltaTime;
            /* Update raid timer image */
            RaidTimerImg.fillAmount = raidTimer / maxTimeBeforeNexRaid;

            /* Timer of next raid */
            if (raidTimer <= 0)
            {
                countSurivedRaids += 1;
                raidTimer = maxTimeBeforeNexRaid;
                warriorCount -= nextRaid;
                nextRaid += countEnemyWarriors;
            }
        }

        /* Timer of harvest increace */
        if (HarvestTimer.Tick)
        {
            breadCount += peopleCount * minedBreadPeople;
            if (countSafeRounds != 0)
                countSafeRounds -= 1;
        }

        /* Timer of food decrease */
        if (FoodTimer.Tick)
        {
            breadCount -= warriorCount * consumptionBreadWarrior;
        }

        /* Begin block input */
        if(breadCount <= 0 || breadCount < peopleCost || createPeoplePressed)
        {
            hirePersonButton.interactable = false;
        }
        else
        {
            TryToEnableButton(hirePersonButton);
        }
        //
        if (breadCount <= 0 || breadCount < warriorCost || createWarriorPressed)
        {
            hireWarrionButton.interactable = false;
        }
        else
        {
            TryToEnableButton(hireWarrionButton);
        }
        /* End block input  */

        /* Timer of people increase */
        if (peopleTimer > 0)
        {
            peopleTimer -= Time.deltaTime;
            /* Update people timer image */
            PeopleTimerImg.fillAmount = peopleTimer / peopleCreateTime;
        }
        else if (peopleTimer > -1)
        {
            /* Return default value for people timer img */
            PeopleTimerImg.fillAmount = 1;
            createPeoplePressed = false;
            TryToEnableButton(hirePersonButton);
            peopleCount += 1;
            peopleTimer = -2;
        }

        /* Timer of warrior increace */
        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            /* Update people timer image */
            WarriorTimerImg.fillAmount = warriorTimer / warriorCreateTime;
        }
        else if (warriorTimer > -1)
        {
            /* Return default value for people timer img */
            WarriorTimerImg.fillAmount = 1;
            createWarriorPressed = false;
            TryToEnableButton(hireWarrionButton);
            warriorCount += 1;
            warriorTimer = -2;
        }

        UpdateResourceText();

        /* Check win/lose game */
        if(warriorCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);

            /* Update stats */
            raidsSurvived.text = countSurivedRaids.ToString();
            producedBread.text = breadCount.ToString();
            peopleSurvived.text = peopleCount.ToString();

            /* Show only if has any warriors */
            if(warriorCount >= 0)
            {
                warriorSurvived.text = warriorCount.ToString();
            }
            else
            {
                warriorSurvived.text = "0";
            }
        }
    }

    private void TryToEnableButton(Button ButtonToEnable)
    {
        /* Check type of button */ 
        if(ButtonToEnable == hirePersonButton)
        {
            /* Additional check */ 
            if(breadCount > 0 && breadCount >= peopleCost)
            {
                hirePersonButton.interactable = true;
                return;
            }
        }
        else if(ButtonToEnable == hireWarrionButton)
        {
            if(breadCount > 0 && breadCount >= warriorCost)
            {
                hireWarrionButton.interactable = true;
                return;
            }
        }
    }

    public void CreatePeople()
    {
        breadCount -= peopleCost;
        peopleTimer = peopleCreateTime;
        hirePersonButton.interactable = false;
        createPeoplePressed = true;
    }

    public void CreateWarrior()
    {
        breadCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        hireWarrionButton.interactable = false;
        createWarriorPressed = true;
    }

    private void UpdateResourceText()
    {
        resourcePeople.text = peopleCount.ToString();
        resourceWarrior.text = warriorCount.ToString();
        resourceBread.text = breadCount.ToString();
        countEnemiesSoon.text = nextRaid.ToString();
        countSafeCycles.text = countSafeRounds.ToString();
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
