using UnityEngine;

public class CubeController1 : MonoBehaviour
{
    private Animator Anim;
    private Rigidbody rg;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Anim.SetFloat("Velocity",rg.angularVelocity.magnitude);
    }
}
