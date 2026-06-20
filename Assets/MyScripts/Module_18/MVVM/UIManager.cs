using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerHUDView HUDView;
    [SerializeField] private AudioSource TargetAudioSource;
    [SerializeField] private AudioClip EmbientSound;

    private PlayerHUDViewModel ViewModel;
    private PlayerHUDModel Model;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if(Player == null)
        {
            Debug.Log("UIManager - Player == null");
            return;
        }

        if(EmbientSound != null)
        {
            if(TargetAudioSource)
            {
                TargetAudioSource.clip = EmbientSound;
                TargetAudioSource.volume = 0.3f;
                TargetAudioSource.loop = true;
                TargetAudioSource.Play();
                Debug.Log("Success play");
            }
            else
            {
                Debug.Log("TargetAudioSource null");
            }
        }
        else
        {
            Debug.Log("EmbientSound null");
        }


        HealthComponent HealthComp = Player.GetComponentInParent<HealthComponent>();
        if(HealthComp == null)
        {
            Debug.Log("UIManager - HealthComp == null");
            return;
        }

        var InventoryComp = Player.GetComponentInParent<InventoryComp>();
        if (InventoryComp == null)
        {
            Debug.Log("UIManager - InventoryComp == null");
            return;
        }

        /* Create model */
        Model = new PlayerHUDModel(HealthComp, InventoryComp);

        /* Create view model */
        ViewModel = new PlayerHUDViewModel(Model);

        if(HUDView != null)
        {
            HUDView.Bind(ViewModel);
        }
    }

    private void OnDestroy()
    {
        /* Clear view model */
        if (ViewModel != null)
        {
           ViewModel.Dispose();
        }
    }

}
