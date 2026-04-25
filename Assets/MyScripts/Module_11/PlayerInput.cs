using Unity.VisualScripting;
using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        private Vector3 Movement;
        private PlayerMovement PlayerMovement;

        private void Awake()
        {
            PlayerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        void Update()
        {
            float Horizntal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float Vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            Movement = new Vector3(Horizntal, 0, Vertical).normalized;
        }

        private void FixedUpdate()
        {
            PlayerMovement.MoveCharacter(Movement);
        }
    }
}
