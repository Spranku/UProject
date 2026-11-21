using UnityEngine;

public class WinCollider : MonoBehaviour
{
    private BoxCollider boxCollider;
    public CrazyRunWinLose winLoseUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            Debug.Log("Win");
            if(winLoseUI)
            {
                winLoseUI.gameObject.SetActive(true);  
                winLoseUI.SetGameResult(true);
            }
        }
    }
}
