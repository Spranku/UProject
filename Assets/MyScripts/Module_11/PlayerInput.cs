using Unity.VisualScripting;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerInput : MonoBehaviour
    {
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("Press A");    
            }

            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Press Fire");
            }


            if (Input.GetButtonDown(GlobalStringVars.JUMP_BUTTON))
            {
                Debug.Log("Jump");
            }

            //Debug.Log((Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS)));

        }
    }
}
