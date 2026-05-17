using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] public float Damage;
    [SerializeField] protected float LifeTime = 0.1f;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);

        if (collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
        }
        else if(collision.name == ("DarkEnemy"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
        }
        
    }
}
