using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Quiz : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    [SerializeField] GameObject[] answerbuttons;
    int correctAnswerIndex;
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;
    #endregion

    #region Unity Methods

    void Start()
    {
        answerbuttons = GameObject.FindGameObjectsWithTag("Answer");

        DisplayQuestion();
    }
    #endregion

    #region Methods
    void DisplayQuestion()
    {
        questionText.text = question.GetQuestion();

        for (int i = 0; i < answerbuttons.Length; i++)
        {
            TextMeshProUGUI buttonText = answerbuttons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetAnswer(i);
        }
    }

    public void OnAnswerSelected(int index)
    {
        if (index == question.GetCorrectAnswerIndex())
        {
            questionText.text = "So True!";
            Image buttonImage = answerbuttons[index].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }
        else
        {
            correctAnswerIndex = question.GetCorrectAnswerIndex();
            string correctAnswer = question.GetAnswer(correctAnswerIndex);
            questionText.text = "YOU WACK, ANSWER WAS \n" + correctAnswer;
            Image buttonImage = answerbuttons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = correctAnswerSprite;
        }

        SetButtonState(false);
    }

    void SetButtonState(bool state)
    {
        for (int i = 0; i < answerbuttons.Length; i++)
        {
            // Why are we not just storing these components in an array / list / dictionary / whatever?
            Button button = answerbuttons[i].GetComponent<Button>();
            button.interactable = state;
        }
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
    }

    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerbuttons.Length; i++)
        {
            Image buttonImage = answerbuttons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }
    #endregion Methods

}