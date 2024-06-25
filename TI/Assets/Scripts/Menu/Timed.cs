using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timed : MonoBehaviour
{
    public static Timed _timeInstance;
    [SerializeField] float timeRemaing = 0f;
    [SerializeField] TextMeshProUGUI timerText;
    int minutes = 0, seconds = 0;

    void Awake()
    {
        if (_timeInstance == null)
            _timeInstance = this;
        else
            Destroy(gameObject);
    }

    public string SetAtualTime()
    {
        timeRemaing += Time.deltaTime;

        minutes = Mathf.FloorToInt(timeRemaing / 60);
        seconds = Mathf.FloorToInt(timeRemaing % 60);

        timerText.text = string.Format("{0:D2}:{1:D2}", minutes, seconds);

        return timerText.text;

    }

    public void Update()
    {
        SetAtualTime();
        AdquirirConquistas();
    }
    public void AdquirirConquistas()
    {
        if(timeRemaing >= 75)
        {
            GameManager.Instance.AddScore(100);
            if(!GameManager.Instance.IsAchievementCompleted("De seus primeiros passos"))
            {
                GameManager.Instance.CompleteAchievement("De seus primeiros passos");
            }
        }
        else if(timeRemaing >= 150)
        {
            GameManager.Instance.AddScore(1000);
            if(!GameManager.Instance.IsAchievementCompleted("Corredor de bairro"))
            {
                GameManager.Instance.CompleteAchievement("Corredor de bairro");
            }
        }
        else if(timeRemaing >= 750)
        {
            GameManager.Instance.AddScore(5000);
            if(!GameManager.Instance.IsAchievementCompleted("Maratonista"))
            {
                GameManager.Instance.CompleteAchievement("Maratonista");
            }
        }
        else if(timeRemaing >= 1500)
        {
            GameManager.Instance.AddScore(10000);
            if(!GameManager.Instance.IsAchievementCompleted("Run Forrest, Run!"))
            {
                GameManager.Instance.CompleteAchievement("Run Forrest, Run!");
            }
        }
    }
}
