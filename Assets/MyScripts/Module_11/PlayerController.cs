using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public bool IsLastLevel = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController") && !IsLastLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.CompareTag("GameController") && IsLastLevel)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex * 0);
        }
    }
}
