using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToCompleteQuestion = 30f;
    [SerializeField] float timeToShowTheCorrectAnswer = 10f;

    public bool loadNextQuestion = true;
    public bool isAnsweringQuestion = false;
    public float fillFraction = 1f; 
    float timerValue;

    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer()
    {
        timerValue = 0;
    }

    void UpdateTimer()
    {
        timerValue -= Time.deltaTime;

        if(timerValue > 0)
        {
            if(isAnsweringQuestion)
            {
                fillFraction = timerValue / timeToCompleteQuestion;
            }
            else
            {
                fillFraction = timerValue / timeToShowTheCorrectAnswer;
            }
        }
        else
        {
            if(isAnsweringQuestion)
            {
                isAnsweringQuestion = false;
                timerValue = timeToShowTheCorrectAnswer;                
            }
            else
            {
                isAnsweringQuestion = true;
                timerValue = timeToCompleteQuestion;
                loadNextQuestion = true;                
            }
        }

        //Debug.Log(isAnsweringQuestion + ": " + timerValue + "= " + fillFraction);
    }
}
