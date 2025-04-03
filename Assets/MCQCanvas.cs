using DG.Tweening;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MCQCanvas : MonoBehaviour
{
    public Category[] category;
    private MCQ mcq;
    public TextMeshProUGUI questionText;
    public Button[] answerTexts;
    public static int categoryIndex;
    void OnEnable()
    {
        Time.timeScale = 0;
        int index = UnityEngine.Random.Range(0, category[categoryIndex].mcqs.Length);
        mcq = category[categoryIndex].mcqs[index];

        questionText.text = mcq.question;
        for (int i = 0; i < answerTexts.Length; i++)
        {
            answerTexts[i].GetComponentInChildren<TextMeshProUGUI>().text = mcq.answers[i];
            answerTexts[i].GetComponent<Image>().color = Color.white;
            answerTexts[i].interactable = true;
        }
    }

    public void ChooseAnswer(int answer)
    {
        bool ans = mcq.Answered(answer);
        Color color = ans ? Color.green : Color.red;
        int soundIndex = ans ? 1 : 2;
        answerTexts[answer].GetComponent<Image>().color = color;
        answerTexts[answer].GetComponent<DOTweenAnimation>().DORestart();
        SoundManager.onPlay?.Invoke(soundIndex);
        CloseCanvas(ans);
        print("Answer: " + ans);
    }

    private void CloseCanvas(bool correct)
    {
        transform.GetChild(1).DOScale(0, 0.5f)
            .SetDelay(0.5f)
            .SetUpdate(true)
            .OnComplete(() =>
            {
            if(correct)
            {
                float probability = UnityEngine.Random.Range(0, 1);
                if(probability > 0.5f)
                {
                    FindObjectOfType<Powers>().ActivateBike();
                }
                else
                {
                    float doubleScore = GameManager.Instance.score;
                    print(doubleScore);
                    GameManager.OnScoreChanged?.Invoke(doubleScore); // double score
                }
            }

            Time.timeScale = 1;
            gameObject.SetActive(false);
            transform.GetChild(1).localScale = Vector3.one;
        });
    }
}

[Serializable]
public class Category
{
    public MCQ[] mcqs;
}
