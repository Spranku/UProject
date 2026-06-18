using Unity.Cinemachine;
using UnityEngine;

public class CatSceneZone : ZoneBase
{
    [SerializeField] private PlayerHUDView playerHUDView;
    [SerializeField] public GameObject CameraTarget;
    [SerializeField] public CinemachineCamera CinemaCamera;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var PlayerInput = collision.gameObject.GetComponentInParent<PF_PlayerInput>();
            if (PlayerInput)
            {
                PlayerInput.CanMove = false;
            }


            if (CinemaCamera)
            {
                CinemaCamera.Follow = CameraTarget.transform;
                CinemaCamera.LookAt = CameraTarget.transform;
            }
        }
    }
}
