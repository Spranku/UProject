using UnityEngine;
using System;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine.UIElements;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected PlayerHUDView View;
    [SerializeField] protected float maxHealth;

    public float MaxHealth => maxHealth;
    public float CurrentHealth => currentHealth;
    public bool IsAlive => bIsAlive;


    protected float currentHealth;
    protected bool bIsAlive;

    /* Events */
    public event Action OnDeath;
    public event Action<float> OnHealthChanged;

    protected void Awake()
    {
        currentHealth = maxHealth;
        bIsAlive = true;
    }

    public virtual void TakeDamage(float Damage)
    {
        if (!bIsAlive) return;

        currentHealth -= Damage;

        OnHealthChanged?.Invoke(currentHealth);

        CheckIsAlive();
    }

    public virtual void AddHealing(float HealingAmount)
    {
        if (!bIsAlive) return;

        if (currentHealth >= maxHealth) return;

        currentHealth = Mathf.Min(currentHealth + HealingAmount, maxHealth);

        OnHealthChanged?.Invoke(currentHealth);
    }

    private void CheckIsAlive() 
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            bIsAlive = false;
            OnDeath?.Invoke();

            var InputComp = gameObject.GetComponentInParent<PF_PlayerInput>();
            if (InputComp)
            {
                InputComp.CanMove = false;
            }

            StartCoroutine(DestroyPlayer());
        }
    }

    private IEnumerator DestroyPlayer()
    {
        yield return new WaitForSeconds(2.0f);
        /* Show lose widget */
        if (View) View.PauseGame(PlayerHUDView.MenuState.Lose);
        gameObject.SetActive(false);
    }
}
