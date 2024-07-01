
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public bool save;
    public static Score instance;

    public Text _currentScore;
    
    public int _score;

    private void Awake() 
    {
        if(instance == null)
            instance = this;
    }

    void Start()
    {
        save = true;
        _currentScore.text = _score.ToString();
        _score = PlayerPrefs.GetInt("ScorePoints");
    }

    void Update()
    {
        _currentScore.text = _score.ToString();
    }
    public void UpdateScore(int amount)
    {
        _score += amount;
        SaveScore();
    }

    public void SaveScore()
    {
        if(save)
        {
            PlayerPrefs.SetInt("ScorePoints", _score);
            PlayerPrefs.Save();
        }
    }
}
