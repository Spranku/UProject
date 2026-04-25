using UnityEngine;
using UnityEngine.SceneManagement;

public class CylinderController : RampController
{
    /* Inherit */

    public override void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
