using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using static PlayerHUDView;
using static UnityEditor.Profiling.HierarchyFrameDataView;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHUDView : MonoBehaviour
{
    public enum MenuState
    {
        Win,
        Lose,
        Pause
    }

    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Image BackgroundImage;
    [SerializeField] private GameObject PauseWidget;
    [SerializeField] private GameObject HUDWidget;
    [SerializeField] private GameObject StatisticOwner;
    [SerializeField] private Button NextButton;
    [SerializeField] private TextMeshProUGUI ScoreForCoinsText;
    [SerializeField] private TextMeshProUGUI ScoreForEnemiesText;
    [SerializeField] private TextMeshProUGUI TotalScoresText;


    private PlayerHUDViewModel ViewModel;

    private void UpdateHealthText(string newText)
    {
        healthText.text = newText;
    }

    private void UpdateScoreText(string NewScoreText)
    {
        scoreText.text = NewScoreText;
    }

    private void UpdateHealthSlider(float newValue)
    {
        healthSlider.value = newValue;
    }

    private void ShowDeathNotification()
    {
        /* Game over */
        healthText.text = "YOU DIED";
        healthText.color = Color.red;
    }

    public void Bind(PlayerHUDViewModel NewViewModel)
    {
        ViewModel = NewViewModel;

        /* Start init */
        healthText.text = NewViewModel.HealthText.Value;
        scoreText.text = NewViewModel.ScoreText.Value;
        healthSlider.value = NewViewModel.HealthPercent.Value;

        /* Bind events */
        NewViewModel.HealthText.OnValueChanged += UpdateHealthText;
        NewViewModel.ScoreText.OnValueChanged += UpdateScoreText;
        NewViewModel.HealthPercent.OnValueChanged += UpdateHealthSlider;
        NewViewModel.OnDeath += ShowDeathNotification;
    }

    public void PauseGame(MenuState inState)
    {
        Time.timeScale = 0.0f;

        switch (inState)
        {
            case MenuState.Win:
                if (BackgroundImage) BackgroundImage.gameObject.SetActive(true);
                if (PauseWidget) PauseWidget.gameObject.SetActive(true);
                if(HUDWidget) HUDWidget.gameObject.SetActive(false);
                /* Check last level */
                if (NextButton && SceneManager.GetActiveScene().buildIndex >= 4)
                {
                    NextButton.gameObject.SetActive(false);
                }
                else
                {
                    NextButton.gameObject.SetActive(true);
                }
                break;
            case MenuState.Lose:
                if (BackgroundImage) BackgroundImage.gameObject.SetActive(true);
                if (PauseWidget) PauseWidget.gameObject.SetActive(true);
                if (NextButton) NextButton.gameObject.SetActive(false);
                if (HUDWidget) HUDWidget.gameObject.SetActive(false);
                break;
            case MenuState.Pause:
                if(!BackgroundImage.IsActive())
                {
                    if (BackgroundImage) BackgroundImage.gameObject.SetActive(true);
                    if (PauseWidget) PauseWidget.gameObject.SetActive(true);
                    if (NextButton) NextButton.gameObject.SetActive(false);
                }
                else
                {
                    if (BackgroundImage) BackgroundImage.gameObject.SetActive(false);
                    if (PauseWidget) PauseWidget.gameObject.SetActive(false);
                    if (NextButton) NextButton.gameObject.SetActive(false);
                    Time.timeScale = 1.0f;
                }
                break;
            default:
                break;
        }
        ShowStats();
    }

    public void ShowStats()
    {
        if(StatisticOwner && TotalScoresText && ScoreForCoinsText && ScoreForEnemiesText)
        {
            var InventoryComp = StatisticOwner.gameObject.GetComponentInParent<InventoryComp>();
            if(InventoryComp)
            {
                TotalScoresText.text = InventoryComp.GetTotalScores().ToString();
                ScoreForCoinsText.text = InventoryComp.GetCurrentScore().ToString();
                ScoreForEnemiesText.text = InventoryComp.GetScoreForKilling().ToString();
            }
        }
    }

    public void OnPauseButtonPressed()
    {
        PauseGame(MenuState.Pause);
    }

    public void OnBackToMenuButtonPressed()
    {
        UnityEngine.Debug.Log("OnBackToMenuButtonPressed");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void OnNextButtonPressed()
    {
        UnityEngine.Debug.Log("OnNextButtonPressed");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnRetryButtonPressed()
    {
        UnityEngine.Debug.Log("OnRetryButtonPressed");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnDestroy()
    {
        if (ViewModel != null)
        {
            /* Unbind */
            ViewModel.HealthText.OnValueChanged -= UpdateHealthText;
            ViewModel.HealthText.OnValueChanged -= UpdateScoreText;
            ViewModel.HealthPercent.OnValueChanged -= UpdateHealthSlider;
            ViewModel.OnDeath -= ShowDeathNotification;
        }
    }
}
