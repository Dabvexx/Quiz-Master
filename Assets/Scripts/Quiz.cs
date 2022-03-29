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
    [Header("Question")]
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] QuestionSO question;
    //[SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    //QuestionSO currentQuestion;

    [Header("Answer")]
    [SerializeField] GameObject[] answerbuttons;
    int correctAnswerIndex;
    bool hasAnsweredEarly;

    [Header("Button Colors")]
    [SerializeField] Sprite correctAnswerSprite;
    [SerializeField] Sprite defaultAnswerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    [SerializeField] Timer timer;
    #endregion

    #region Unity Methods

    void Start()
    {
        answerbuttons = GameObject.FindGameObjectsWithTag("Answer");

        GetNextQuestion();
        //DisplayQuestion();
    }

    private void Update()
    {
        timerImage = GameObject.FindGameObjectWithTag("Timer").GetComponent<Image>();
        timerImage.fillAmount = timer.fillFraction;

        if(timer.loadNextQuestion)
        {
            hasAnsweredEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        }
        else if (!hasAnsweredEarly && !timer.isAnsweringQuestion)
        {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
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
    void DisplayAnswer(int index)
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
    }

    void GetNextQuestion()
    {
        SetButtonState(true);
        SetDefaultButtonSprites();
        DisplayQuestion();
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
    void SetDefaultButtonSprites()
    {
        for (int i = 0; i < answerbuttons.Length; i++)
        {
            Image buttonImage = answerbuttons[correctAnswerIndex].GetComponent<Image>();
            buttonImage.sprite = defaultAnswerSprite;
        }
    }

    public void OnAnswerSelected(int index)
    {
        hasAnsweredEarly = true;
        DisplayAnswer(index);

        SetButtonState(false);
        timer.CancelTimer();
    }
    #endregion Methods

}