using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DamageComponent : MonoBehaviour
{
    [SerializeField] protected float Damage;
    [SerializeField] protected float LifeTime = 0.1f;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Damageable"))
        {
            collision.gameObject.GetComponent<HealthComponent>().TakeDamage(Damage);
        }

        //Destroy(gameObject);
        //Coroutine coroutine = StartCoroutine(DestroyObject(LifeTime));
    }

    //private IEnumerator DestroyObject(float LifeTime)
    //{
    //    yield return new WaitForSeconds(LifeTime);
    //    Destroy(gameObject);
    //}
}
