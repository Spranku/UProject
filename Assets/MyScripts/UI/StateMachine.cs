using UnityEngine;

public class StateMachine : MonoBehaviour
{
    [SerializeField] private GameObject firstScreen;
    [SerializeField] private GameObject secondScreen;

    private GameObject currentScreen;

    private void Start()
    {
        firstScreen.SetActive(true);
        currentScreen = firstScreen;
    }

    public void ChangeState(GameObject state)
    {
        if(currentScreen != null)
        {
            currentScreen.SetActive(false);
            state.SetActive(true);
            currentScreen = state;
        }
    }
}
