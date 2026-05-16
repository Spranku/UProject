using UnityEngine;

public class ShooterComponent : MonoBehaviour
{
    [SerializeField] protected GameObject Bullet;
    [SerializeField] protected float FireSpeed;
    [SerializeField] protected Transform ShootPoint;

    public virtual void Shoot(float Direction)
    {
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
}
