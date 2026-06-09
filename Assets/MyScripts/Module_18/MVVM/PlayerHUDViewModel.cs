using UnityEngine;

public  class PlayerHUDViewModel
{
    private PlayerHUDModel Model;

    /* Reactive properties for view */
    public ReactiveProperty<string> HealthText { get; private set; }
    public ReactiveProperty<string> ScoreText { get; private set; }
    public ReactiveProperty<float> HealthPercent { get; private set; }

    public event System.Action OnDeath;

    public void TakeDamage(float NewDamage)
    {
        Model.TakeDamage(NewDamage);
    }

    public void AddCoin(byte NewCoin)
    {
        Model.AddCoin(NewCoin);
    }

    private void OnHealthChanged(float NewHealth)
    {
        UpdateTextAndPercent(NewHealth);
    }

    private void UpdateTextAndPercent(float NewCurrentHealth)
    {
        if (HealthText != null)
        {
            HealthText.Value = $"{NewCurrentHealth} / {Model.MaxHealth.Value}";
        }

        if (Model.MaxHealth.Value > 0)
        {
            float percent = NewCurrentHealth / Model.MaxHealth.Value;
            if (HealthPercent != null)
            {
                HealthPercent.Value = percent;
            }
        }
    }

    private void UpdateScoreText(byte NewCurrentScore)
    {
        if (ScoreText != null)
        {
            ScoreText.Value = Model.CurrentScore.Value.ToString();
        }
    }

    private void OnModelHealthChanged(float newHealth)
    {
        UpdateTextAndPercent(newHealth);
    }

    private void OnModelScoreChanged(byte newScore)
    {
        UpdateScoreText(newScore);
    }

    public PlayerHUDViewModel(PlayerHUDModel NewModel)
    {
        Model = NewModel;

        /* First init */
        string initialText = $"{Model.CurrentHealth.Value} / {Model.MaxHealth.Value}";
        float initialPercent = Model.MaxHealth.Value > 0 ? Model.CurrentHealth.Value / Model.MaxHealth.Value : 0f;

        HealthText = new ReactiveProperty<string>(initialText);
        ScoreText = new ReactiveProperty<string>("0");
        HealthPercent = new ReactiveProperty<float>(initialPercent);

        /* Subscribe on view model actions */
        Model.CurrentHealth.OnValueChanged += OnModelHealthChanged;
        Model.CurrentScore.OnValueChanged += OnModelScoreChanged;
        Model.OnDeath += () => OnDeath?.Invoke();
    }

    public void Dispose()
    {
        if (Model != null)
        {
            Model.CurrentHealth.OnValueChanged -= OnModelHealthChanged;
            Model.CurrentScore.OnValueChanged -= OnModelScoreChanged;
        }
    }
}

