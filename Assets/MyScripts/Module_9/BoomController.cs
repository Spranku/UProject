using UnityEngine;
using UnityEngine.UIElements;

public class BoomController : MonoBehaviour
{
    public float TimeToExplosion;
    public float Power;
    public float Radius;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimeToExplosion -= Time.deltaTime;

        if(TimeToExplosion <= 0)
        {
            Boom();
        }
    }

    void Boom()
    {
        Rigidbody[] block = FindObjectsOfType<Rigidbody>();

        foreach (Rigidbody b in block)
        {
            if(Vector3.Distance(transform.position, b.transform.position) < Radius)
            {
                Vector3 Direction = b.transform.position - transform.position;

                b.AddForce(Direction.normalized * Power * (Radius - Vector3.Distance(transform.position, b.transform.position)), ForceMode.Impulse);
            }
        }


        TimeToExplosion = 3;
    }
}
