using System.Collections;
using UnityEngine;

public class CorutinesSample : MonoBehaviour
{
    private void Start()
    {
        Coroutine coroutine = StartCoroutine(timer());
    }

    private IEnumerator timer()
    {
        for(int i = 0; i < 10; ++i)
        {
            Debug.Log(i);
            yield return new WaitForSeconds(2);
        }


    }
}
