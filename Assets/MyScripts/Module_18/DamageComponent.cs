using UnityEngine;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] protected float Damage;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
        }

        //Destroy(gameObject);
    }
}
