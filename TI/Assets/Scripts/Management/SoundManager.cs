using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instanceAudio;
    [SerializeField] AudioSource _audioSource;

    private void Awake() 
    {
        if(instanceAudio == null)
        {
            instanceAudio = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    public void Jump()
    {
        _audioSource.Play();
    }
}
