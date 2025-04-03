using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Transform targetPoint;
    public ParticleSystem groundEffect;
    public Camera_Orbit virtualCamera;
    public static bool hasSarted = false;
    public TMP_Dropdown dropdown;
    private void Awake()
    {
        hasSarted = false;

        // Load saved selection when the game starts
        if (PlayerPrefs.HasKey("mcqs"))
        {
            dropdown.value = PlayerPrefs.GetInt("mcqs");
            MCQCanvas.categoryIndex = PlayerPrefs.GetInt("mcqs");
        }
;
    }

    public void SaveSelection(int value)
    {
        PlayerPrefs.SetInt("mcqs", value);
        PlayerPrefs.Save(); // Ensure it's saved
    }
    public void Play()
    {
        hasSarted = true;
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        player.DOMove(targetPoint.position, 0.1f)
            .SetDelay(0.5f)
            .SetEase(Ease.Linear)
            .OnComplete(() =>
            {
                player.GetComponent<Animator>().Play("Action pose");
                groundEffect.Play();
                virtualCamera.ShakeCamera(5);
                GetComponent<AudioSource>().Play();
            });

        transform.DOMove(transform.position, 1.5f)
            .OnComplete(() =>
            {
                player.GetComponent<Player>().enabled = true;
                gameObject.SetActive(false);
            });
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
}
