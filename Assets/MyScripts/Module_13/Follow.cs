using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform PlayerTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerTransform.position;
    }
}
