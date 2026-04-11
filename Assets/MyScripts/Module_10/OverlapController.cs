using UnityEngine;

public class OverlapController : MonoBehaviour
{
    public float rad;
    public LayerMask LayerM;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Collider[] colls = Physics.OverlapSphere(transform.position, rad, LayerM);

        foreach(var col in colls)
        {
            Destroy(col.gameObject);
            Debug.Log(col.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
