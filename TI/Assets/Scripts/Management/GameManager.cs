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

    public void Cemiterio () 
    {
        SceneManager.LoadScene("Cemiterio");
    }

    public void Biblioteca()
    {
        SceneManager.LoadScene("Biblioteca");
    }

    public void Village()
    {
        SceneManager.LoadScene("Village");
    }

    public void SelectFases()
    {
        SceneManager.LoadScene("SelectFases");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("Die");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void Quit()
    {
        Application.Quit();
    }
}
