using Unity.VisualScripting;
using UnityEngine;

public class SoftLaunchObject : SoftLaunchPlatform
{
    [SerializeField, Range(1, 3)] public int NumOfInteractions = 1;
    public GameObject FirstGameObject;
    public GameObject SecondGameObject;
    public GameObject ThirdGameObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        rg = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
        if (other.CompareTag("GameController"))
        {
            Launch();
        }
    }

    protected override void Update() { }

    protected override void Launch()
    {
        Debug.Log("Launch");
        if(NumOfInteractions == 1)
        {
            FirstGameObject.gameObject.SetActive(false);
        }
        else if(NumOfInteractions == 2)
        {
            SecondGameObject.gameObject.SetActive(false);
        }
        else if(NumOfInteractions == 3)
        {
            ThirdGameObject.gameObject.SetActive(false);
        }
    }
}
