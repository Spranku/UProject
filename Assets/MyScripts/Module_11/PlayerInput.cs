using Unity.VisualScripting;
using UnityEngine;

namespace WildBall.Inputs
{
    //[RequireComponent(typeof(PlayerMovement))]
    public class PlayerInput : MonoBehaviour
    {
        public bool CanMove = false;
        private Vector3 Movement;
        public PlayerMovement playerMovement;

        public virtual void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        // Update is called once per frame
        public virtual void Update()
        {
            float Horizntal = Input.GetAxis(GlobalStringVars.HORIZONTAL_AXIS);
            float Vertical = Input.GetAxis(GlobalStringVars.VERTICAL_AXIS);

            Movement = new Vector3(Horizntal, 0, Vertical).normalized;
        }

        private void FixedUpdate()
        {
            playerMovement.MoveCharacter(Movement);
        }
    }
}
