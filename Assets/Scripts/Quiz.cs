using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Quiz : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerbuttons;
    #endregion

    #region Unity Methods

    void Start()
    {
        answerbuttons = GameObject.FindGameObjectsWithTag("Answer");
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerbuttons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
     
        }
    }
    #endregion

}