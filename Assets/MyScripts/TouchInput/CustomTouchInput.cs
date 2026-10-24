using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CustomTouchInput : MonoBehaviour
{
    public Text text;

    bool bSuccesSwipe = false;
    float currentTime = 0f;
    float duration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (text.gameObject.activeSelf)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
            }
            else
            {
                currentTime = 0f;
                text.gameObject.SetActive(false);
            }

        }

        if (Input.touchCount > 0)
        {
            var Touch = Input.GetTouch(0);
            var currentPosition = Touch.position;

            /* Can swap? */
            if(Touch.rawPosition.x >= 500.0f)
            {
                /* Min 100 pixels */
                if(currentPosition.x <= 400.0f)
                {
                    if (bSuccesSwipe)
                    {
                        return;
                    }
                    else
                    {
                        bSuccesSwipe = true;
                        ShowInfo();
                    }
                }
            }
        }
    }

    void ShowInfo()
    {
        if(text)
        {
            currentTime = duration;
            text.gameObject.SetActive(true);
            bSuccesSwipe = false;
        }
    }
}
