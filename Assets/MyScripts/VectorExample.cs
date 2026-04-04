using System;
using Unity.VisualScripting;
using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public Transform pointStart;
    public Transform pointEnd;
    public Transform tempPoint;

    public GameObject cube;

    //private Transform pos;
    
    public const int NumPoints = 3;

    public float speed = 1.0f;
    public bool bIsMove = true;
    public bool bIsRotateZ = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /* Init array of zero vectors */
        Vector3[] VectorArr = new Vector3[NumPoints];
        Vector3[] ReverseArr = new Vector3[NumPoints];

        /* Set start position for cube */

        Int32 index = 0;
        const float offset = 5.0f;

        /* Array of different vectors */
        for (Int32 i = 0; i < VectorArr.Length; ++i)
        {
            ++index;
            VectorArr[i].y += offset;
            VectorArr[i].x += (index * offset);

            /* Start point position = position by frist index from the array */
            pointStart.position = VectorArr[i];
            /* Setup current position for launch move func */
            transform.position = pointStart.position;
            /* Setup start position for move func */
            tempPoint.position = pointStart.position;
            /* Add ready point to ReverseArr */
            ReverseArr[i] = pointStart.position;
        }
        

        //Debug.Log(ReverseArr.Length);

        for (int i = ReverseArr.Length - 1; i >= 0; i--)
        {
            /* Save end point position every iteration */
            pointEnd.position = ReverseArr[i];
            /* Setup current position for move func */
            transform.position = pointEnd.position;
        }
        
    }

    void MoveTo(bool bIsMove)
    {
        if(bIsMove && transform.position != tempPoint.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, tempPoint.position, Time.deltaTime * speed);
        }
        else
        {
            tempPoint.position = pointEnd.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /* Add rotate */
        if(bIsRotateZ)
        {
            cube.transform.Rotate(0,speed,0);
        }

        MoveTo(true);
        
        ///* Flip flop */
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
