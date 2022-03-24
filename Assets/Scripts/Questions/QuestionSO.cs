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
    #endregion

    #region Public Methods
    public string GetQuestion()
    {
        return question;
    }
    #endregion 
}