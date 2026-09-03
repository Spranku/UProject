using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float RightXPosition = 5.0f;
    public float LeftXPosition = 3.5f;
    private bool bIsReturn = false;
    private SliderJoint2D myJoint;
    private JointMotor2D myMotor;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myJoint = GetComponent<SliderJoint2D>();
        if (myJoint != null)
        {
            myMotor = myJoint.motor;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!bIsReturn &&  transform.position.x <= LeftXPosition)
        {
            myMotor.motorSpeed = -1;
            myJoint.motor = myMotor;
            bIsReturn = true;
        }
        else if(bIsReturn && transform.position.x >= RightXPosition)
        {
            myMotor.motorSpeed = 1;
            myJoint.motor = myMotor;
            bIsReturn = false;
        }
    }
}
