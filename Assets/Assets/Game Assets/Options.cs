using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Options : MonoBehaviour
{
    public Slider X, Y, mxSpeed, dead_Zone;
    // Start is called before the first frame update
    void Start()
    {
        X.value = CameraFollow.smoothSpeedx;
        Y.value = CameraFollow.smoothSpeedy;
        mxSpeed.value = PlayerPrefs.GetFloat("speed", 30);
        dead_Zone.value = PlayerPrefs.GetFloat("deadzone", 125f);
    }

    public void smoothX(float x)
    {
        CameraFollow.smoothSpeedx = x;
    }
    public void smoothY(float y)
    {
        CameraFollow.smoothSpeedy = y;
    }

    public void maxSpeed(float s)
    {
        PlayerPrefs.SetFloat("speed", s);
    }
    public void deadZone(float d)
    {
        SwipeManager.Offset = d;
    }

    public void save()
    {
        PlayerPrefs.SetFloat("x", CameraFollow.smoothSpeedx);
        PlayerPrefs.SetFloat("y", CameraFollow.smoothSpeedy);
        PlayerPrefs.SetFloat("deadzone", SwipeManager.Offset);
    }
}
