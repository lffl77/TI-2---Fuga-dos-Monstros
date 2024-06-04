using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    #region Variables
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button returnButton;
    public Button soundButton;
    public Button menuButton;


    private bool isPaused = false;
    #endregion

    #region Functions
    void Start()
    {
        soundButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.onClick.AddListener(GamePause);
        returnButton.onClick.AddListener(ReturnGame);
    }

    void GamePause()
    {
        if (!isPaused)
        {
            pauseMenu.SetActive(true);
            soundButton.gameObject.SetActive(true);
            menuButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            returnButton.gameObject.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }

    void ReturnGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(false);
            soundButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }
    #endregion
}