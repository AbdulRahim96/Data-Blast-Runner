using UnityEngine;

public class quality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        QualitySettings.SetQualityLevel(PlayerPrefs.GetInt("quality", 2));
    }

    // Update is called once per frame
    public void changeLevels(int level)
    {
        QualitySettings.SetQualityLevel(level);
        PlayerPrefs.SetInt("quality", level);
        
    }
}
