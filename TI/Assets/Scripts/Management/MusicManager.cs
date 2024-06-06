using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Variables
    private AudioSource audioSource;
    public static MusicManager musicManager;
    #endregion

    #region Unity Callbacks
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
            PlayMusic();
        else
            Debug.LogError("No AudioSource component found.");
    }
    #endregion

    #region Public Methods
    public void PlayMusic() 
    {
        if (audioSource != null)
            audioSource.Play();    
        else
            Debug.LogError("No AudioSource component found.");
    }

    public void PauseMusic() 
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Pause();    
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
            audioSource.Stop(); 
    }

    public bool IsPlaying()
    {
        return audioSource != null && audioSource.isPlaying;
    }
    #endregion
}
