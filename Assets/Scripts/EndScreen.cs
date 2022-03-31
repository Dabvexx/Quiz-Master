using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndScreen : MonoBehaviour
{
    #region Variables
    [SerializeField] TextMeshProUGUI finalScoreText;
    ScoreKeeper scoreKeeper;
    #endregion

    #region Unity Methods
    void Awake()
    {
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
    }
    #endregion

    #region Public Methods
    public void ShowFinalScore()
    {
        finalScoreText.text = "Congratulations!\nYou got a score of " +
                                scoreKeeper.CalculateScore() + "%";
    }

    #endregion
}
