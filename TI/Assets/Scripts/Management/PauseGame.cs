using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour
{
    #region Variables
    public GameObject pauseMenu;
    public Button pauseButton;
    public Button returnButton;
    public Button soundButton;
    public Button menuButton;

    private bool isPaused = false;

    // Referência estática ao MusicManager
    private static MusicManager musicManager;
    #endregion

    #region Functions
    void Start()
    {
        // Obtém a referência ao MusicManager
        musicManager = FindObjectOfType<MusicManager>();

        soundButton.gameObject.SetActive(false);
        menuButton.gameObject.SetActive(false);
        returnButton.gameObject.SetActive(false);
        pauseMenu.SetActive(false);
        pauseButton.onClick.AddListener(GamePause);
        returnButton.onClick.AddListener(ReturnGame);
        soundButton.onClick.AddListener(ToggleSound);
        menuButton.onClick.AddListener(GoToMenu);
    }

    void GamePause()
    {
        if (!isPaused)
        {
            // Pausa a música
            if (musicManager != null)
                musicManager.PauseMusic();

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
            // Retorna a reprodução da música
            if (musicManager != null)
                musicManager.PlayMusic();

            pauseMenu.SetActive(false);
            soundButton.gameObject.SetActive(false);
            menuButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(true);
            returnButton.gameObject.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }
    }

    void ToggleSound()
    {
        if (musicManager != null)
        {
            if (musicManager.IsPlaying())
                musicManager.StopMusic();
            else
                musicManager.PlayMusic();
        }
    }

    void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    #endregion
}
