using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _gmInstance;
    public static Score score;

    public Transform player;


    [SerializeField] private GameObject _screens;

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
        _screens.SetActive(false);
    }

    public void GameOver()
    {
        _screens.SetActive(true);
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
