using UnityEngine;
using UnityEngine.Playables;

public class Ability : MonoBehaviour
{
    public PlayableDirector timeline;
    private Transform sourceTransform;
    private Vector3 originalScale;

    private void Start()
    {
        originalScale = gameObject.transform.localScale;
        sourceTransform = gameObject.transform;

        timeline = GetComponent<PlayableDirector>();    
        if(timeline)
        {
            Debug.Log("Success timeline");
        }
    }

    public void ChangeScale()
    {
        var newScale = new Vector3(.5f,.1f,1f);
        gameObject.transform.localScale = newScale;
        Debug.Log("ChangeScale");
    }

    public void AddRigidbody()
    {
        gameObject.AddComponent<Rigidbody>();
        var rg = GetComponent<Rigidbody>();
        if(rg)
        {
            rg.useGravity = true;
            rg.isKinematic = false;
        }
        Debug.Log("Success AddRigid");
    }

    public void OnDestroy()
    {
        Debug.Log("Success destroy");
        gameObject.SetActive(false);
    }
}
