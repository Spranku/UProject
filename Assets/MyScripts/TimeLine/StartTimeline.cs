using UnityEngine;
using UnityEngine.Playables;

public class MonoBehaviourScript : MonoBehaviour
{
    private PlayableDirector timeline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeline = GetComponent<PlayableDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            timeline.Play();
            Debug.Log("Space");
        }
    }
}
