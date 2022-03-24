using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    #region Variables
    // Variables.
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowCorrectAnswer = 10f;

    public bool loadNextQuestion;
    public float fillFraction;

    bool isAnsweringQuestion;
    float timerValue;
    #endregion

    #region Unity Methods
    void Update()
    {
        UpdateTimer();
    }
    #endregion

    #region Private Methods
    // Private Methods.
    void UpdateTimer()
    {
        // Bro there is literally a timer in the system namespace this is so complicated.
        // If I had time id make this so much simpler.
        timerValue -= Time.deltaTime;
        
        if(isAnsweringQuestion)
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowCorrectAnswer;
            }
        }
        else
        {
            if(timerValue > 0)
            {
                fillFraction = timerValue / timeToShowCorrectAnswer;
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToShowCorrectAnswer;
            }
        }
    }

    void CancelTimer()
    {
        timerValue = 0;
    }
    #endregion

    #region Public Methods
    // Public Methods.
    
    #endregion
}