using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public Runner RunnerToSpawn;
    public int NumOfRunners = 3;
    public float SpawnOffset = 5.0f;
    public float RunnerSpeed = 5.0f;
    public float PassDistance = 0.5f;

    private int currentRunnerIndex = 0;
    private int direction = 1;

    private Runner[] RunnersArray;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Runner[] TempRunnersArray = new Runner[NumOfRunners];

        for(int i = 0; i < NumOfRunners; ++i)
        {
            /* Clone the runner */
            Runner newRunner = Instantiate(RunnerToSpawn);
            /* Set start position */
            newRunner.transform.position = new Vector3(0 + (SpawnOffset * i), 0, 0);
            /* Init values for runner */
            newRunner.RunnerID = i;
            newRunner.speed = RunnerSpeed;
            newRunner.passDistance = PassDistance;
            newRunner.rs = this;

            /* Set next position */
            int nextIndex = (i + 1) % NumOfRunners;
            newRunner.NextPosition = new Vector3(0 + (SpawnOffset * nextIndex), 0, 0);

            /* Save runner to temp array */
            TempRunnersArray[i] = newRunner;
        }
        /* Launch first runner */
        TempRunnersArray[0].Launch(true);

        /* Save runners array*/
        InitRunnersArray(TempRunnersArray);
    }

    public void InitRunnersArray(Runner[] inArr)
    {
        RunnersArray = inArr;
    }

    public void OnRunnerReachedTarget(int runnerID)
    {
        RunnersArray[runnerID].StopRunning();

        int nextID = (runnerID + 1) % NumOfRunners;

        /* If new cycle starts */
        if (nextID == 0)
        {
            /* Cleanup to start positions */
            for (int i = 0; i < NumOfRunners; i++)
            {
                Vector3 startPos = new Vector3(0 + (SpawnOffset * i), 0, 0);
                RunnersArray[i].transform.position = startPos;

                /* Update target for all runners */
                int targetIndex = (i + 1) % NumOfRunners;
                RunnersArray[i].NextPosition = new Vector3(0 + (SpawnOffset * targetIndex), 0, 0);
            }

            /* launch first runner again*/
            RunnersArray[0].Launch(true);
        }
        else
        {
            /* Default move */
            int targetIndex = (nextID + 1) % NumOfRunners;
            RunnersArray[nextID].NextPosition = new Vector3(0 + (SpawnOffset * targetIndex), 0, 0);
            RunnersArray[nextID].Launch(true);
        }
    }
}
