using System;
using Unity.IO.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AnimObjectController : MonoBehaviour
{
    protected Animator Anim;

    public virtual void Awake()
    {
        Anim = GetComponent<Animator>();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }
        //Anim.SetTrigger("Trigger");
    }

    public virtual void OnTriggerExit(Collider other)
    {
       // Anim.SetBool("EndOverlap", true);
        //GetRandomBool();
    }

    protected virtual void GetRandomBool() 
    {
        bool randomBool = UnityEngine.Random.value > 0.5f;
        Anim.SetBool("Rand",randomBool);
    }
}
