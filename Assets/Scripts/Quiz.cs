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
    #endregion

    #region Unity Methods

    void Start()
    {
        questionText.text = question.GetQuestion();
    }
    #endregion

}