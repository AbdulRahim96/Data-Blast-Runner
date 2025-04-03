using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{

    public static bool tap, swipeLeft, swipeRight, swipeUp, swipeDown, disable;
    private Vector2 startTouch, swipeDelta;
    private bool isDragging = false;
    public static float offset = 1f; // DeadZone Offset

    public Vector2 SwipeDelta { get { return swipeDelta; } }
    public bool Tap { get { return tap; } }
    public bool SwipLeft { get { return swipeLeft; } }
    public bool SwipeRight { get { return swipeRight; } }
    public bool SwipeUp { get { return swipeUp; } }
    public bool SwipeDown { get { return swipeDown; } }

    private void Start()
    {
        offset = PlayerPrefs.GetFloat("deadzone", 125f);
    }
    // Update is called once per frame
    void Update()
    {
        swipe();
    }

    private void swipe()
    {
        if (disable == false)
        {
            tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

            #region Standalone
            if (Input.GetMouseButtonDown(0))
            {
                tap = isDragging = true;
                startTouch = Input.mousePosition;
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isDragging = false;
                Reset();
            }
            #endregion

            #region Mobile Controls

            if (Input.touchCount > 0)
            {
                if (Input.touches[0].phase == TouchPhase.Began)
                {
                    tap = isDragging = true;
                    startTouch = Input.touches[0].position;
                    Vector3 targetPos = transform.position + new Vector3(3, 0, 0);
                   // transform.position = targetPos;
                }
                else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
                {
                    isDragging = false;
                    Reset();
                }
            }
            #endregion

            #region Distance Calculations
            swipeDelta = Vector2.zero;
            if (isDragging)
            {
                if (Input.touchCount > 0)
                {
                    swipeDelta = Input.touches[0].position - startTouch;
                }
                else if (Input.GetMouseButton(0))
                {
                    swipeDelta = (Vector2)Input.mousePosition - startTouch;
                }
            }
            #endregion

            #region Direction Define
            if (swipeDelta.magnitude > offset)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;

                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    if (x > 0)
                    {
                        swipeRight = true;
                        Debug.Log("right");
                    }
                    else
                    {
                        swipeLeft = true;
                        Debug.Log("left");
                    }
                }
                else
                {
                    if (y > 0)
                    {
                        swipeUp = true;
                        Debug.Log("up");
                    }
                    else
                    {
                        swipeDown = true;
                        Debug.Log("down");
                    }
                }
                Reset();
            }
            #endregion
        }
    }

    private void Reset()
    {
        swipeDelta = startTouch = Vector2.zero;
        isDragging = false;
    }
}
