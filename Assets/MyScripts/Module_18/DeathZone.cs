using UnityEngine;

public class DeathZone : ZoneBase
{
    [SerializeField] private PlayerHUDView playerHUDView;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            var Movement = collision.gameObject.GetComponentInParent<PF_PlayerMovement>();
            if (Movement)
            {
                Movement.HandleDeath();
            }

            if (playerHUDView) playerHUDView.PauseGame(PlayerHUDView.MenuState.Lose);
        }
    }
}
