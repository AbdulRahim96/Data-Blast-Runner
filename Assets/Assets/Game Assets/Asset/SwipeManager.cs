using System.Collections;
using UnityEngine;

public class SwipeManager : MonoBehaviour
{
    public static bool Tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    public static float Offset = 125f;

    private Vector2 startTouch;
    private Vector2 swipeDelta;

    public Vector2 SwipeDelta => swipeDelta;
    public bool IsTap => Tap;
    public bool IsSwipeLeft => swipeLeft;
    public bool IsSwipeRight => swipeRight;
    public bool IsSwipeUp => swipeUp;
    public bool IsSwipeDown => swipeDown;

    private void Awake()
    {
        Offset = PlayerPrefs.GetFloat("deadzone", 125f);
    }

    private void OnEnable()
    {
        StartCoroutine(SwipeListener());
    }

    private IEnumerator SwipeListener()
    {
        while (true)
        {
            Tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

            // Detect input begin
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                Tap = true;
                startTouch = Input.touches[0].position;
                yield return WaitForEndOrCancelTouch();
            }
            else if (Input.GetMouseButtonDown(0))
            {
                Tap = true;
                startTouch = Input.mousePosition;
                yield return WaitForEndOrCancelMouse();
            }

            yield return null;
        }
    }

    private IEnumerator WaitForEndOrCancelTouch()
    {
        while (Input.touchCount > 0 &&
               (Input.touches[0].phase == TouchPhase.Moved || Input.touches[0].phase == TouchPhase.Stationary))
        {
            swipeDelta = Input.touches[0].position - startTouch;

            if (swipeDelta.magnitude > Offset)
            {
                DetectSwipeDirection(swipeDelta);
                break;
            }

            yield return null;
        }

        Reset();
    }

    private IEnumerator WaitForEndOrCancelMouse()
    {
        while (Input.GetMouseButton(0))
        {
            swipeDelta = (Vector2)Input.mousePosition - startTouch;

            if (swipeDelta.magnitude > Offset)
            {
                DetectSwipeDirection(swipeDelta);
                break;
            }

            yield return null;
        }

        Reset();
    }

    private void DetectSwipeDirection(Vector2 delta)
    {
        float x = delta.x;
        float y = delta.y;

        if (Mathf.Abs(x) > Mathf.Abs(y))
        {
            if (x > 0) swipeRight = true;
            else swipeLeft = true;
        }
        else
        {
            if (y > 0) swipeUp = true;
            else swipeDown = true;
        }
    }

    private void Reset()
    {
        startTouch = swipeDelta = Vector2.zero;
    }
}
