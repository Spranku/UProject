using UnityEngine;

public class RampController : AnimObjectController
{
    public override void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        Anim.SetTrigger("Trigger");
    }

    public override void OnTriggerExit(Collider other)
    {
        Debug.Log("Exit");
        Anim.SetBool("EndOverlap", true);
    }
}
