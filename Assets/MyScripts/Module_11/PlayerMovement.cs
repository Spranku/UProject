using Unity.VisualScripting;
using UnityEngine;

namespace WildBall.Inputs
{
    //[RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public AudioSource MainAudioSource;
        public AudioClip HitSound;
        [SerializeField, Range(0, 10)] private float Speed = 2.0f;
        private Rigidbody playerRigidbody;

        public virtual void Awake()
        {
            playerRigidbody = GetComponent<Rigidbody>();
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.CompareTag("Wall"))
            {
                PlayHitSound(true);
            }
            else
            {
                PlayHitSound(false);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (!collision.collider.CompareTag("Wall"))
            {
                PlayHitSound(false);
            }
 
        }

        public virtual void Move(float Direction, bool bIsJumpButtonPressed)
        {

        }

        public void MoveCharacter(Vector3 NewMovement)
        {
            if (!playerRigidbody) return;

            playerRigidbody.AddForce(NewMovement * Speed);
            Vector3 Zero = new Vector3(0, 0, 0);
            if (NewMovement == Zero)
            {
                PlayMoveSound(false);
            }
            else
            {
                PlayMoveSound(true);
            }
        }

        protected virtual void PlayHitSound(bool bIsActive)
        {
            if (!HitSound) return;

            if (bIsActive)
            {
                MainAudioSource.PlayOneShot(HitSound);
            }
            else
            {
                if (MainAudioSource.isPlaying) MainAudioSource.Stop();
            }
        }

        protected virtual void PlayMoveSound(bool bIsActive)
        {
            if (!MainAudioSource) return;

            if (bIsActive) 
            {
                if (!MainAudioSource.isPlaying) MainAudioSource.Play(); 
            }
            else
            {
                if(MainAudioSource.isPlaying) MainAudioSource.Stop();
            }
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

