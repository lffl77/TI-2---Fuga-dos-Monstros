using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gmInstance;
    public static Score score;

    public Transform player;

    [SerializeField] private GameObject _gameOverAndStart;
    //[SerializeField] private GameObject _initialScreen;

    private void Awake() 
    {
        if(_gmInstance == null)
        {
            _gmInstance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        Time.timeScale = 1f;
    }

    private void Start () 
    {
        _gameOverAndStart.SetActive(false);
        //_initialScreen.SetActive(true);
    }

    private void Help()
    {
        //_initialScreen.SetActive(true);
    }

    public void GameOver()
    {
        _gameOverAndStart.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
