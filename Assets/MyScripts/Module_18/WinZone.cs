using UnityEngine;

public class WinZone : ZoneBase
{
    [SerializeField] private PlayerHUDView playerHUDView;

    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(playerHUDView) playerHUDView.PauseGame(PlayerHUDView.MenuState.Win);
        } 
    }

}
