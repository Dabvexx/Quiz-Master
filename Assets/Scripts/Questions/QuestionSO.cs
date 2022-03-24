using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    #region Variables
    // Variables.
    [TextArea(2,6)]
    [SerializeField] string question = "Enter question text here";

    // Personally, i would make the questions able to be randomized where they are displayed,
    // and have the first answer in the array to be the correct answer.
    [SerializeField] string[] answers = new string[4];
    [SerializeField] int correctAnswerIndex;
    #endregion

    #region Public Methods
    public string GetQuestion()
    {
        return question;
    }

    public string GetAnswer(int index)
    {
        return answers[index];
    }

    public int GetCorrectAnswerIndex()
    {
        return correctAnswerIndex;
    }
    #endregion 
}