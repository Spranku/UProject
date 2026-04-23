using UnityEngine;

public class CoinController : MonoBehaviour
{
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Anim.SetBool("Alive", false);
        Anim.SetTrigger("Collect");
        Destroy(gameObject, 0.5f);
    }

    public void DestroySomething()
    {
        //Destroy(FindObjectOfType<MeshFilter>().gameObject);
        ///Destroy(FindFirstObjectByType<MeshFilter>().gameObject);
    }
}
