using System;
using UnityEngine;
using UnityEngine.Events;
using static RootMotion.FinalIK.Grounding;

public class QualityDetector : MonoBehaviour
{
    public Quality[] qualities; // Array of quality settings
    void Start()
    {
        if (!PlayerPrefs.HasKey("GraphicsQuality"))
        {
            int quality = DetectQualityLevel();
            qualities[quality].ApplyQuality();
            PlayerPrefs.SetInt("GraphicsQuality", quality);
        }
        else
        {
            // Load saved quality setting
            int savedQuality = PlayerPrefs.GetInt("GraphicsQuality");
            qualities[savedQuality].ApplyQuality();
        }
    }

    int DetectQualityLevel()
    {
        // Sample heuristic: you can tweak this based on tests
        int ramMB = SystemInfo.systemMemorySize;
        int vramMB = SystemInfo.graphicsMemorySize;
        int cpuCores = SystemInfo.processorCount;
        print($"RAM: {ramMB}MB, VRAM: {vramMB}MB, CPU Cores: {cpuCores}");

        if (ramMB <= 2000 || vramMB <= 512 || cpuCores <= 4)
        {
            return 0; // Low
        }
        else if (ramMB <= 4000 || vramMB <= 1024)
        {
            return 1; // Medium
        }
        else
        {
            return 2; // High
        }
    }
}

[Serializable]
public class Quality
{
    public string qualityName;
    public int qualityLevel;
    public UnityEvent onQualityApplied;

    public void ApplyQuality()
    {
        QualitySettings.SetQualityLevel(qualityLevel, true);
        onQualityApplied?.Invoke();
    }
}
