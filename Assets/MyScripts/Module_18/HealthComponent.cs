using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    protected bool bIsAlive;
    public event Action OnDeath;

    protected void Awake()
    {
        currentHealth = maxHealth;
        bIsAlive = true;
    }

    public virtual void TakeDamage(float Damage)
    {
        if (currentHealth >= Damage)
            currentHealth -= Damage;
        CheckIsAlive();
    }

    private void CheckIsAlive() 
    {
        bIsAlive = currentHealth > 0 ? true : false;

        if(!bIsAlive)
        {
            Debug.Log(gameObject.name + "is death");
            OnDeath?.Invoke();
        }
    }
}
