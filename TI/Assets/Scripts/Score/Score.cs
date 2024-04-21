
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{


    //Mudar score para timer(Temporizador)
    
    public static Score instance;

    [SerializeField] private TextMeshProUGUI _currentScore;
    //[SerializeField] private TextMeshProUGUI _bestScore;
    
    public int _score;

    private void Awake() 
    {
        if(instance == null)
            instance = this;    
    }

    void Start()
    {
        _currentScore.text = _score.ToString();

        //_bestScore.text = PlayerPrefs.GetInt("bestPoints", 0).ToString();
        //UpdateBestScore();
    }

    
    /*public void UpdateBestScore()
    {
        if(_score > PlayerPrefs.GetInt("bestPoints"))
        {
            PlayerPrefs.GetInt("bestPoints", 0);
            _bestScore.text = _score.ToString();
        }
    }*/

    public void UpdateScore()
    {
        _score++;
        _currentScore.text = _score.ToString();
        //UpdateBestScore();
    }
}
