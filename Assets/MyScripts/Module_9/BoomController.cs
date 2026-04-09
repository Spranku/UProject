using UnityEngine;
using UnityEngine.UIElements;

public class BoomController : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;

    private bool CanBoom = true;

    // Update is called once per frame
    void Update()
    {
        TimeToExplosion -= Time.deltaTime;

        if(TimeToExplosion <= 0 && CanBoom)
        {
            Boom();
        }
    }

    void Boom()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, Radius);

        foreach (var hitCollider in hitColliders)
        {
            Rigidbody rb = hitCollider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(Power, transform.position, Radius, 1f, ForceMode.Impulse);
                CanBoom = false;
            }
        }

        TimeToExplosion = 3;
    }
}
