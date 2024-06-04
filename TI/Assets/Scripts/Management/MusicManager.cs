using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    #region Variables
    private AudioSource audioSouce;
    #endregion

    #region Functions
    void Start()
    {
        audioSouce = GetComponent<AudioSource> ();
        PlayMusic();
    }

    public void PlayMusic() 
    {
        if(audioSouce.isPlaying)
            audioSouce.Play();    
    }
    public void PauseMusic() 
    {
        if(audioSouce.isPlaying)
            audioSouce.Pause();    
    }
    public void StopMusic()
    {
        if(audioSouce.isPlaying)
            audioSouce.Stop(); 
    }
    public bool IsPlaying()
    {
        return audioSouce.isPlaying;
    }
    #endregion
}
