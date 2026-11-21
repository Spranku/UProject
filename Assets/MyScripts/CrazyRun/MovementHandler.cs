using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MovementHandler : MonoBehaviour
{
    [SerializeField]
    public InputHandler inputHandler;
    [SerializeField] 
    public float forceMultiplier = 1.0f;

    private Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (inputHandler == null)
        {
            Debug.Log("Input handler = null");

            InputHandler comp = FindAnyObjectByType<InputHandler>();
            if (comp == null) Debug.Log("InputHandler = null");
            inputHandler = comp;
        }

        rb =GetComponentInParent<Rigidbody>();
        if (rb == null) Debug.LogError("На шарике нет Rigidbody!");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveBall();
    }

    private void MoveBall()
    {
        if(inputHandler.IsThereTouchOnScreen())
        {
            Vector2 delta = inputHandler.GetTouchDeltaPosition();

            if (delta.sqrMagnitude > 0)
            {
                Vector3 forceDirection = new Vector3(delta.x, 0f, delta.y);

                rb.AddForce(forceDirection * forceMultiplier, ForceMode.Force);
            }
        }
    }
}
