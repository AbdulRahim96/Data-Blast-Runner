using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSetup : MonoBehaviour
{
    public static bool isFarm;
    public GameObject torch, sunLight;
    void Awake()
    {
        torch.SetActive(!isFarm);
        sunLight.SetActive(isFarm);
    }
}
