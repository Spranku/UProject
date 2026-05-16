using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    [SerializeField] protected float maxHealth;
    protected float currentHealth;
    protected bool bIsAlive;

    protected void Awake()
    {
        currentHealth = maxHealth;
        bIsAlive = true;
    }

    public virtual void TakeDamage(float Damage)
    {
        currentHealth -= Damage;
        CheckIsAlive();
    }

    private void CheckIsAlive() 
    {
        bIsAlive = currentHealth > 0 ? true : false;
    }
}
