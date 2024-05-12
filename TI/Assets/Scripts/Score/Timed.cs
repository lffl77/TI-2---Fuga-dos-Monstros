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
    }
}
