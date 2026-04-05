using UnityEngine;

public class RunnerSpawner : MonoBehaviour
{
    public Runner RunnerToSpawn;
    public int NumOfRunners = 3;
    public float SpawnOffset = 5.0f;
    public float RunnerSpeed = 5.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Runner[] Arr = new Runner[NumOfRunners];

        for(int i = 0; i < NumOfRunners - 1; ++i)
        {
            Runner newRunner = Instantiate(RunnerToSpawn);
            newRunner.transform.position = new Vector3(0 + (SpawnOffset * i), 0, 0);
            newRunner.RunnerID = i;

            newRunner.NextPosition = new Vector3(0 + (SpawnOffset * (i+1)), 0, 0);
            Arr[i] = newRunner;
        }

        
        Arr[0].Launch(true,Arr[0].NextPosition);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
