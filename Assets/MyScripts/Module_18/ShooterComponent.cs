using UnityEngine;
using System.Collections;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float FireSpeed;
    [SerializeField] protected Transform ShootPoint;
    [SerializeField] private Animator ShooterAnimator;

    public virtual void Shoot(float Direction)
    {
        Coroutine coroutine = StartCoroutine(DisableShootAnim());
        ShooterAnimator.SetBool("IsAttack", true);

        GameObject currentBullet = Instantiate(Bullet, ShootPoint.position, Quaternion.identity);
        Rigidbody2D currentBulletVelocity = currentBullet.GetComponent<Rigidbody2D>();

        if(Direction >= 0)
        {
            currentBulletVelocity.linearVelocity = new Vector2(FireSpeed * 1, currentBulletVelocity.linearVelocity.y);
        }
        else
        {
            currentBulletVelocity.linearVelocity = new Vector2(FireSpeed * (-1), currentBulletVelocity.linearVelocity.y);
        }
    }

    private IEnumerator DisableShootAnim()
    {
        yield return new WaitForSeconds(0.3f);
        ShooterAnimator.SetBool("IsAttack", false);
    }
}


