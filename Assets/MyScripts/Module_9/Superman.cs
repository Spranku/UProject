using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;

public class Superman : MonoBehaviour
{
    public float SupermanPower = 0.1f;
    public float SupermanSpeed = 0.5f;

    private Rigidbody rb;
    private Vector3 Direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        /* Set direction for superman*/
        Direction = new Vector3(100.0f, 1.0f, 1.0f);
    }

    private void Update()
    {
        /* Infinit superman moving */
        transform.position = Vector3.MoveTowards(transform.position, Direction, Time.deltaTime * SupermanSpeed);  
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.rigidbody != null)
        { 
            /* Get center of objects */
            Vector3 SelfPos = transform.position;
            Vector3 EnemyPos = collision.transform.position;

            /* Save laucch direction */
            var Direction = EnemyPos - SelfPos;

            /* Launch */
            collision.rigidbody.AddForce(Direction.normalized * SupermanPower, ForceMode.Impulse);
        }
    }
}
