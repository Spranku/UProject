using Unity.IO.LowLevel.Unsafe;
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
        Anim.SetBool("EndOverlap",true);
    }
}
