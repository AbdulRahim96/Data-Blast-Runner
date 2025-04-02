using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MCQ", menuName = "MCQ/Create new")]
public class MCQ : ScriptableObject
{
    public string question;
    public string[] answers;
    public int correctAnswer;

    public bool Answered(int answer)
    {
        return answer == correctAnswer;
    }
}
