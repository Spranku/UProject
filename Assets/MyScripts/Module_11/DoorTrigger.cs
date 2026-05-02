using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    public Button ActionButton;
    private bool isPlayerInTrigger = false;

    private void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            OpenDoor();
            Debug.Log("E press");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("GameController"))
        {
            isPlayerInTrigger = true;
            ActionButton.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("GameController"))
        {
            isPlayerInTrigger = false;
            ActionButton.gameObject.SetActive(false);
        }
    }

    public void OpenDoor()
    {
        doorAnimator.SetTrigger("Open");
    }

}
