using Unity.VisualScripting;
using UnityEngine;

public class VectorExample : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;
    public GameObject cube;
    public float speed = 1.0f;
    public bool bIsMove = true;
    public bool bIsRotateZ = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 vec = new Vector3(1,1,0);
        //transform.rotation = Quaternion.Euler(45, 45, 45);



        vec.x = point1.position.x;
        vec.y = point1.position.y;  
        vec.z = point1.position.z;  

        /* Init array of zero vectors */
        Vector3[] VectorArr = new Vector3[3] { (Vector3.zero),(Vector3.zero),(Vector3.zero) };

        for (int i = 0; i < VectorArr.Length; ++i)
        {
            //VectorArr[i].x = 
        }

    }

    void MoveTo(Transform PositionToMove, bool bIsMove)
    {
        if(bIsMove && transform.position != PositionToMove.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, PositionToMove.position, Time.deltaTime * speed);
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

        MoveTo(point1, true);
        
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
