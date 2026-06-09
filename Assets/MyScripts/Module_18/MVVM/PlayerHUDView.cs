using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class PlayerHUDView : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Slider healthSlider;

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
