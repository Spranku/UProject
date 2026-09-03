using UnityEngine;
using UnityEngine.UI;


public class TestHUD : MonoBehaviour
{
    public Image[] Panels;
    [SerializeField]
    public Sprite ActiveSprite;
    [SerializeField]
    public Sprite UnactiveSprite;

    public void Start()
    {
        /* First initialize */
        for(int i = 0; i < Panels.Length; ++i)
        {
            Panels[i].sprite = UnactiveSprite;
        }

        var FirstImage = Panels[0].gameObject.GetComponent<Image>();
        if(FirstImage)
        {
            FirstImage.sprite = ActiveSprite;
        }
    }

    public void SetActiveElement(byte Index)
    {
        for(int i = 0; i < Panels.Length; ++i)
        {
            Panels[i].sprite = UnactiveSprite;
        }

        Panels[Index].sprite = ActiveSprite;
    }
}
