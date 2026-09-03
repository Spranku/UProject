using TMPro;
using Unity.VisualScripting;
//using UnityEditor.AdaptivePerformance.Editor;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    /* My class */
    public ImagerTimer HarvestTimer;
    public ImagerTimer FoodTimer;

    /* Sound */
    public AudioClip buttonClickSound;
    public AudioClip harvestSound;
    public AudioClip peopleSound;
    public AudioClip warriorSound;
    public AudioClip enemisSound;
    public AudioClip foodSound;
    public AudioClip gameSound;
    public AudioClip winSound;
    public AudioClip loseSound;
    public AudioSource audioSource;
    bool isSoundEnabled = true;

    /* Screens */
    public GameObject GameOverScreen;
    public GameObject GameWinScreen;
    public GameObject GamePauseScreen;

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

    /* Game settings */
    public int minedBreadPeople;
    public int consumptionBreadWarrior;
    public int peopleCost;
    public int warriorCost;
    public float peopleCreateTime;
    public float warriorCreateTime;
    public float maxTimeBeforeNexRaid;
    public int countEnemyWarriors;
    public int countSafeRounds;
    public int nextRaid;
    public int countBreadToWin;

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

    /* Final stats variables */
    private int countSurivedRaids;

    /* Timer variables */
    private float raidTimer;
    private float peopleTimer = -2;
    private float warriorTimer = -2;

    /* Helper flugs */
    private bool createPeoplePressed;
    private bool createWarriorPressed;
    private bool gameEnded = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;

        /* Disabling all useless screens with new game started */
        GameOverScreen.SetActive(false);
        GameWinScreen.SetActive(false);
        GamePauseScreen.SetActive(false);

        /* Launch ambient */
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        audioSource.clip = gameSound;
        audioSource.loop = true;
        audioSource.Play();

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
        if (gameEnded) return;

        /* Launch raid timer only if has`nt safe rounds */
        if (countSafeRounds == 0)
        {
            raidTimer -= Time.deltaTime;
            /* Update raid timer image */
            RaidTimerImg.fillAmount = raidTimer / maxTimeBeforeNexRaid;

            /* Timer of next raid */
            if (raidTimer <= 0)
            {
                PlayActionSound(enemisSound);
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

            Debug.Log("Harvest!");
            /* Play harvest sound */
            PlayActionSound(harvestSound);

            if (countSafeRounds != 0)
                countSafeRounds -= 1;
        }

        /* Timer of food decrease */
        if (FoodTimer.Tick)
        {
            breadCount -= warriorCount * consumptionBreadWarrior;
            PlayActionSound(foodSound);
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
            PlayActionSound(peopleSound);
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
            PlayActionSound(warriorSound);
            warriorCount += 1;
            warriorTimer = -2;
        }

        UpdateResourceText();

        /* Check win/lose game */
        if(warriorCount < 0)
        {
            gameEnded = true;
            /* Clear other sounds an launcg lose sound */
            audioSource.Stop();
            PlayActionSound(loseSound);

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

        if(breadCount >= countBreadToWin)
        {
            gameEnded = true;
            /* Clear other sounds an launcg win sound */
            audioSource.Stop();
            PlayActionSound(winSound);

            Time.timeScale = 0;
            GameWinScreen.SetActive(true);
            return;
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

    public void PlayButtonClick()
    {
        audioSource.PlayOneShot(buttonClickSound);
    }

    public void PlayActionSound(AudioClip ClipToPlay)
    {
        audioSource.PlayOneShot(ClipToPlay);
    } 

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetGamePause(bool bIsPause)
    {
        //float currentVolume = AudioListener.volume;

        if(bIsPause)
        {
            Time.timeScale = 0;
            GamePauseScreen.SetActive(true);
            //AudioListener.volume = 0.1f;
        }
        else
        {
            Time.timeScale = 1;
            GamePauseScreen.SetActive(false);
            //AudioListener.volume = currentVolume;
        }
    }

    public void SetSoundEnabled()
    {
        isSoundEnabled = !isSoundEnabled;
        AudioListener.volume = isSoundEnabled ? 0.7f : 0.0f;
    }

    public void ExitToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu_SaveTheVillage");
    }
}
