using System;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;


public class AnimObjectController : MonoBehaviour
{
    protected Animator Anim;

    public virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Anim.SetTrigger("Trigger");
    }

    public virtual void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        Anim.SetBool("EndOverlap", true);
        GetRandomBool();
    }

    protected virtual void GetRandomBool() 
    {
        bool randomBool = UnityEngine.Random.value > 0.5f;
        Anim.SetBool("Rand",randomBool);
    }
}
