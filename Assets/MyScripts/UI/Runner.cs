using UnityEngine;

public class Runner : MonoBehaviour
{
    public RunnerSpawner rs;
    public int RunnerID = 0;
    public Vector3 NextPosition = Vector3.zero;
    public float speed;
    public float passDistance;
    public bool CanMove = false;


    private bool hasPassed = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Launch(bool bCanMove,Vector3 newVec)
    {
        CanMove = bCanMove;
        NextPosition = newVec;
    }

    public void Launch(bool startMoving)
    {
        CanMove = startMoving;
        hasPassed = false;
    }

    public void StopRunning()
    {
        CanMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanMove || hasPassed) return;

        float distanceToTarget = Vector3.Distance(transform.position,NextPosition);

        if (distanceToTarget <= passDistance && !hasPassed)
        {
            hasPassed = true;
            CanMove = false;
            rs.OnRunnerReachedTarget(RunnerID);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position,
                                                     NextPosition,
                                                     Time.deltaTime * speed);
        }

    }
}
