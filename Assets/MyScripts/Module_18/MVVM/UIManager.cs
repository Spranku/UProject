using UnityEngine;
using static UnityEditor.Profiling.HierarchyFrameDataView;

public class UIManager : MonoBehaviour
{
    [SerializeField] private PlayerHUDView HUDView;

    private PlayerHUDViewModel ViewModel;
    private PlayerHUDModel Model;

    private void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        if(Player == null)
        {
            Debug.Log("Player == null");
            return;
        }

        HealthComponent HealthComp = Player.GetComponent<HealthComponent>();
        if(HealthComp == null)
        {
            Debug.Log("HealthComp == null");
            return;
        }

        /* Create model */
        Model = new PlayerHUDModel(HealthComp);

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
