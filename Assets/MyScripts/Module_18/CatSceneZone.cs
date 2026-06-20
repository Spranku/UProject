using TMPro;
using Unity.Cinemachine;
using UnityEngine;
using System.Collections;
using TMPro;

public class CatSceneZone : ZoneBase
{
    [SerializeField] private PlayerHUDView playerHUDView;
    [SerializeField] public GameObject CatSceneCanvas;
    [SerializeField] public GameObject CameraTarget;
    [SerializeField] public CinemachineCamera CinemaCamera;
    [SerializeField] public string[] Dialogs;
    [SerializeField] public TextMeshProUGUI DialogText;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var PlayerInput = collision.gameObject.GetComponentInParent<PF_PlayerInput>();
            if (PlayerInput)
            {
                PlayerInput.CanMove = false;
            }

            if(playerHUDView)
            {
                playerHUDView.HideHUD();
            }

            if(CatSceneCanvas)
            {
                CatSceneCanvas.SetActive(true);
            }

            if (CinemaCamera)
            {
                CinemaCamera.Follow = CameraTarget.transform;
                CinemaCamera.LookAt = CameraTarget.transform;
            }

            StartCoroutine(ShowDialogsWithDelay());
        }
    }

    private IEnumerator ShowDialogsWithDelay()
    {
        yield return new WaitForSecondsRealtime(1.0f);

        for (int i = 0; i < Dialogs.Length; i++)
        {
            DialogText.text = Dialogs[i];

            yield return new WaitForSecondsRealtime(3.0f);
        }

        CatSceneCanvas.SetActive(false);

        if (playerHUDView)
        {
            playerHUDView.PauseGame(PlayerHUDView.MenuState.Win);
        }
    }
}
