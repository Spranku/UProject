using TMPro;
using Unity.VisualScripting;
using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.UI;

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

    /* */
    public int pricePeople;
    public int priceWarrior;
    public int peopleCost;
    public int warriorCost;

    /* Text variables */
    public TMP_Text resourcePeople;
    public TMP_Text resourceWarrior;
    public TMP_Text resourceBread;

    public float peopleCreateTime;
    public float warriorCreateTime;
    public float raidMaxTime;
    public int raidIncrease;
    public int nextRaid;

    /* Timer variables */
    private float peopleTimer = -2;
    private float warriorTimer = -2;
    private float raidTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameOverScreen.SetActive(false);
        UpdateResourceText();
        raidTimer = raidMaxTime;
    }

    // Update is called once per frame
    void Update()
    {
        raidTimer -= Time.deltaTime;
        /* Update raid timer image */
        RaidTimerImg.fillAmount = raidTimer / raidMaxTime;

        if (raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            warriorCount -= nextRaid;
            nextRaid += raidIncrease;
        }

        if (HarvestTimer.Tick)
        {
            breadCount += peopleCount * pricePeople;
            Debug.Log(breadCount);
        }

        if (FoodTimer.Tick)
        {
            breadCount -= warriorCount * priceWarrior;
            Debug.Log(breadCount);
        }

        if(peopleTimer > 0)
        {
            peopleTimer -= Time.deltaTime;
            /* Update people timer image */
            PeopleTimerImg.fillAmount = peopleTimer / peopleCreateTime;
        }
        else if(peopleTimer > -1)
        {
            /* Return default value for people timer img */
            PeopleTimerImg.fillAmount = 1;
            hirePersonButton.interactable = true;
            peopleCount += 1;
            peopleTimer = -2;
        }

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
            hireWarrionButton.interactable = true;
            warriorCount += 1;
            warriorTimer = -2;
        }

        UpdateResourceText();

        if(warriorCount < 0)
        {
            Time.timeScale = 0;
            GameOverScreen.SetActive(true);
        }
    }

    public void CreatePeople()
    {
        breadCount -= peopleCost;
        peopleTimer = peopleCreateTime;
        hirePersonButton.interactable = false;
    }

    public void CreateWarrior()
    {
        breadCount -= warriorCost;
        warriorTimer = warriorCreateTime;
        hireWarrionButton.interactable = false;
    }

    private void UpdateResourceText()
    {
        resourcePeople.text = peopleCount.ToString();
        resourceWarrior.text = warriorCount.ToString();
        resourceBread.text = breadCount.ToString();
    }
}
