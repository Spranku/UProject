using System;
using System.Data;
using UnityEngine;

public class PlayerHUDModel 
{
    private HealthComponent HealthComponent;
    private InventoryComp InvenoryComponent;

    /* Reactive properties for view */
    public ReactiveProperty<float> CurrentHealth { get; private set; }
    public ReactiveProperty<byte> CurrentScore { get; private set; }
    public ReactiveProperty<float> MaxHealth { get; private set; }

    /* Events */
    public event Action OnDeath;

    private void HandleComponentDeath()
    {
        OnDeath?.Invoke();
    }

    public PlayerHUDModel(HealthComponent NewHealthComponent, InventoryComp NewInventoryComp)
    {
        HealthComponent = NewHealthComponent;
        InvenoryComponent = NewInventoryComp;

        /* Init start values */
        MaxHealth = new ReactiveProperty<float>(NewHealthComponent.MaxHealth);
        CurrentHealth = new ReactiveProperty<float>(NewHealthComponent.CurrentHealth);
        CurrentScore = new ReactiveProperty<byte>(0);

        // Bind to death 
        HealthComponent.OnDeath += HandleComponentDeath;

        /* Bind to change HP */
        HealthComponent.OnHealthChanged += (NewHP) =>
        {
            CurrentHealth.Value = NewHP;
        };

        /*Bind to CoinComp*/
        InvenoryComponent.OnScoreChanged += (NewScore) =>
        {
            Debug.Log("OnScoreChanged = " + NewScore);
            CurrentScore.Value = NewScore;
        };
    }

    public void TakeDamage(float NewDamage)
    {
        HealthComponent.TakeDamage(NewDamage);

        CurrentHealth.Value = HealthComponent.CurrentHealth;
    }

    public void AddCoin(byte NewCoin)
    {
        InvenoryComponent.AddScore(NewCoin);
        CurrentScore.Value = InvenoryComponent.CurrentScore;
    }

    /* Destroy model */
    public void Dispose()
    {
        HealthComponent.OnDeath -= HandleComponentDeath;
    }
}
