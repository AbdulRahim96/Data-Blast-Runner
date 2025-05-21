using UnityEngine;
using Cinemachine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.EventSystems;

public class Camera_Orbit : MonoBehaviour
{
    public static Camera_Orbit instance;
    public bool isInstace = true;
    private CinemachineVirtualCamera cinemachineCamera;
    private CinemachineBasicMultiChannelPerlin noise;

    public float shakeDuration = 0.5f; // Default shake duration

    private Tween tween;
    private void Awake()
    {
        if(isInstace)
            instance = this;
        cinemachineCamera = GetComponent<CinemachineVirtualCamera>();
        noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        
    }

    public void ShakeCamera(float intensity)
    {
        float from = intensity;
        float currentFrequency = noise.m_FrequencyGain;

        if (tween != null)
        {
            if (tween.IsPlaying())
                return;
            else
                tween.Kill();
        }
        print(gameObject.name);
        tween = DOTween.To(() => from, x => from = x, currentFrequency, shakeDuration)
                .OnUpdate(() =>
                {
                    noise.m_FrequencyGain = from;
                });
    }

    public void ShakeCamera(CinemachineVirtualCamera cinemachineCamera)
    {
        CinemachineBasicMultiChannelPerlin noise = cinemachineCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        float from = 10;
        float currentFrequency = noise.m_FrequencyGain;
        print(cinemachineCamera.gameObject.name);
        if (tween != null)
        {
            if (tween.IsPlaying())
                return;
            else
                tween.Kill();
        }

        tween = DOTween.To(() => from, x => from = x, currentFrequency, shakeDuration)
                .OnUpdate(() =>
                {
                    noise.m_FrequencyGain = from;
                });
    }

    public void ShakeCameraMove(float sprinting)
    {
        /*float amp = sprinting ? 2 : 0;
        float freq = sprinting ? 0.05f : 0;

        noise.m_AmplitudeGain = amp;
        noise.m_FrequencyGain = freq;*/
    }

    public void SetFarClipPlane(float val)
    {
        cinemachineCamera.m_Lens.FarClipPlane = val;
    }
}
