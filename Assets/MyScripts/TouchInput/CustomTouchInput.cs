using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using Unity.Cinemachine;

public class CustomTouchInput : MonoBehaviour
{
    public Text text;
    public Camera MainCam;

    bool bSuccesSwipe = false;
    float currentTime = 0f;
    float duration = 1f;

    Vector2 fakeFinger = new Vector2(150f, 150f);
    float prevDistance = 0f;

    // Update is called once per frame
    void Update()
    {
        #region Hide info timer
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
        #endregion

        if (Input.touchCount > 0)
        {
            var Touch = Input.GetTouch(0);
            var currentPosition = Touch.position;

            #region Swipe
            /* Can swipe? */
            if (Touch.rawPosition.x >= 500.0f)
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
            #endregion

            #region Zoom
            if (Input.touchCount == 2 || true)
            {
                Vector2 touchPos = Touch.position;
                Vector2 fakeFingerPos = fakeFinger;
                float currentDistance = Vector2.Distance(touchPos, fakeFingerPos);

                if (Touch.phase == TouchPhase.Began || prevDistance == 0f)
                {
                    prevDistance = currentDistance;
                }
                else
                {
                    float deltaDistance = currentDistance - prevDistance;

                    if (deltaDistance > 10f)
                    {
                        Zoom(true);
                    }
                    else if (deltaDistance < -2f)
                    {
                        Zoom(false);
                    }
                    prevDistance = currentDistance;
                }

            }
            #endregion
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

    void Zoom(bool InZoom)
    {
        if (!MainCam) return;

        if(InZoom)
        {
            if(MainCam.fieldOfView != 110f)
                MainCam.fieldOfView = 110f;
        }
        else
        {
            if (MainCam.fieldOfView != 60f)
                MainCam.fieldOfView = 60f;
        }
    }
}
