using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class PlayerHUDView : MonoBehaviour
{
    [SerializeField] private Text healthText;
    [SerializeField] private Slider healthSlider;

    private PlayerHUDViewModel ViewModel;

    private void UpdateText(string newText)
    {
        healthText.text = newText;
    }

    private void UpdateSlider(float newValue)
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
        healthSlider.value = NewViewModel.HealthPercent.Value;

        /* Bind events */
        NewViewModel.HealthText.OnValueChanged += UpdateText;
        NewViewModel.HealthPercent.OnValueChanged += UpdateSlider;
        NewViewModel.OnDeath += ShowDeathNotification;
    }

    private void OnDestroy()
    {
        if (ViewModel != null)
        {
            /* Unbind */
            ViewModel.HealthText.OnValueChanged -= UpdateText;
            ViewModel.HealthPercent.OnValueChanged -= UpdateSlider;
            ViewModel.OnDeath -= ShowDeathNotification;
        }
    }
}
