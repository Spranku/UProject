using UnityEngine;

public class Runner : MonoBehaviour
{
    public int RunnerID = 0;
    public Vector3 NextPosition = Vector3.zero;
    public float speed = 5.0f;
    public bool CanMove = false;

    private RunnerSpawner manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Debug.Log("I was spawned" + RunnerID);
    }

    void MoveToNextRunner(bool CanMove, Vector3 VectorToMove)
    {
        if (CanMove && transform.position != VectorToMove)
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     VectorToMove,
                                                     Time.deltaTime * speed);
        }
        else
        {
            Debug.Log("transform.position == VectorToMove");
            CanMove = false;
            NextPosition = transform.position;
        }
    }

    public void Launch(bool bCanMove,Vector3 newVec)
    {
        CanMove = bCanMove;
        NextPosition = newVec;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToNextRunner(CanMove, NextPosition);
    }
}
