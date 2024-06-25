
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public bool save;
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScore;
    
    public int _score;

    private void Awake() 
    {
        if(instance == null)
            instance = this;    
    }

    void Start()
    {
        _currentScore.text = _score.ToString();
        _score = PlayerPrefs.GetInt("ScorePoints");
    }


    public void Update()
    {
        SaveScore();
    }
    public void UpdateScore()
    {
        _score++;
    }

    public void SaveScore()
    {
        if(save == true)
        {
            PlayerPrefs.SetInt("ScorePoints", _score);
            PlayerPrefs.Save();
        }
    }
}
