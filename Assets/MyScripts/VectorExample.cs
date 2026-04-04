using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class VectorExample : MonoBehaviour
{
    /* Additional for UI */
    public Text distanceText;

    /* Point variables */
    public Transform pointStart;
    public Transform pointEnd;
    public Transform pointTemp;
    
    /* Point move settings */
    public bool CanMove = true;
    public bool IsInfiniteMove = false;
    public int NumOfPoints = 5;
    public float pointOffset = 5.0f;
    public float moveSpeed = 1.0f;

    /* Flags */
    private bool bForward = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* First task */
        SetupPointToPointMovementSystem();
    }

    void SetupPointToPointMovementSystem()
    {
        /* Create empty arrays with size from inspector */
        var VectorArr = new Vector3[NumOfPoints];
        var ReverseArr = new Vector3[NumOfPoints];

        Int32 index = 0;
        for (Int32 i = 0; i < VectorArr.Length; ++i)
        {
            ++index;
            VectorArr[i].y += pointOffset;
            VectorArr[i].x += (index * pointOffset);

            /* Start point position = position by frist index from the array */
            pointStart.position = VectorArr[i];
            /* Setup current position for launch move func */
            transform.position = pointStart.position;
            /* Setup start position for move func */
            pointTemp.position = pointStart.position;
            /* Add ready point to ReverseArr */
            ReverseArr[i] = pointStart.position;
        }

        for (int i = ReverseArr.Length - 1; i >= 0; i--)
        {
            /* Save end point position every iteration */
            pointEnd.position = ReverseArr[i];
            /* Setup current position for move func */
            transform.position = pointEnd.position;
        }
    }
    void MovePointToPoint(bool bIsMove, bool bInfiniteMove)
    {
        if(!IsInfiniteMove)
        {
            /* Activation once from Start to End point and reverse */
            if (bIsMove && transform.position != pointTemp.position)
            {
                var Distance = Vector3.Distance(transform.position,pointTemp.position);
                distanceText.text = Distance.ConvertTo<int>().ToString();
                transform.position = Vector3.MoveTowards(transform.position, pointTemp.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                pointTemp.position = pointEnd.position;
            }
        }
        else
        {
            /* Activation infinite loop */
            if (bIsMove && transform.position != pointTemp.position)
            {
                var Distance = Vector3.Distance(transform.position, pointTemp.position);
                distanceText.text = Distance.ConvertTo<int>().ToString();
                transform.position = Vector3.MoveTowards(transform.position, pointTemp.position, Time.deltaTime * moveSpeed);
                if (!bForward && transform.position == pointEnd.position)
                {
                    bForward = true;
                    pointTemp.position = pointStart.position;
                    return;
                }
            }
            else
            {
                pointTemp.position = pointEnd.position;
                bForward = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        MovePointToPoint(CanMove,IsInfiniteMove);
        
        //if(transform.position != pointUp.position && bIsMove)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pointUp.position, Time.deltaTime * speed);
        //    //transform.LookAt(pointUp.position);
        //}
        //else if(transform.position == pointUp.position && bIsMove)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, pointDown.position, Time.deltaTime * speed);
        //    //transform.LookAt(pointDown.position);
        //}
        //transform.LookAt(point1.position);
        //transform.position = Vector3.Lerp(transform.position, point1.position, 0.1f);
        /* Simpe move to ... */
        //transform.position = Vector3.MoveTowards(transform.position, point1.position, Time.deltaTime);
    }
}
