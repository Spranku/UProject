using UnityEngine;

namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField, Range(0, 10)] private float Speed = 2.0f;
        private Rigidbody playerRigidbody;

        private void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        public void MoveCharacter(Vector3 NewMovement)
        {
            playerRigidbody.AddForce(NewMovement * Speed);
        }

#if UNITY_EDITOR
        [ContextMenu("Reset Values")]
        public void ResultValues()
        {
            Speed = 2.0f;
        }
#endif
    }
}

