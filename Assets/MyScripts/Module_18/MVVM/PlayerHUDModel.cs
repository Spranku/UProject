using System;
using UnityEngine;

public class PlayerHUDModel 
{
    private HealthComponent HealthComponent;

    /* Reactive properties for view */
    public ReactiveProperty<float> CurrentHealth { get; private set; }
    public ReactiveProperty<float> MaxHealth { get; private set; }

    /* Events */
    public event Action OnDeath;

    private void HandleComponentDeath()
    {
        OnDeath?.Invoke();
    }

    public PlayerHUDModel(HealthComponent NewHealthComponent)
    {
        HealthComponent = NewHealthComponent;

        /* Init start values */
        MaxHealth = new ReactiveProperty<float>(NewHealthComponent.MaxHealth);
        CurrentHealth = new ReactiveProperty<float>(NewHealthComponent.CurrentHealth);

        // Bind to death 
        HealthComponent.OnDeath += HandleComponentDeath;
        /* Bind to change HP */
        HealthComponent.OnHealthChanged += (NewHP) =>
        {
            CurrentHealth.Value = NewHP;
        };
    }

    public void TakeDamage(float NewDamage)
    {
        HealthComponent.TakeDamage(NewDamage);

        CurrentHealth.Value = HealthComponent.CurrentHealth;
    }

    /* Destroy model */
    public void Dispose()
    {
        HealthComponent.OnDeath -= HandleComponentDeath;
    }
}
