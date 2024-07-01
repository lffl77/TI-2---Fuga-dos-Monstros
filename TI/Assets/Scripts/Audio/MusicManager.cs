using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    #region Variables
    [SerializeField] private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    public static MusicManager musicManager;
    #endregion

    #region Unity Callbacks

    private void Awake() 
    {
        if(musicManager == null)
        {
            musicManager = this;
            DontDestroyOnLoad(this.gameObject);
        }    
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Config")
        {
            musicSlider = FindObjectOfType<Slider>();
            if (musicSlider != null)
            {
                musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });
                LoadVolume();
            }
        }
    }
    #endregion

    #region Public Methods
        public void SetMusicVolume()
        {
            float volume = musicSlider.value;
            audioMixer.SetFloat("music", Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat("musicVolume", volume);
        }

        public void LoadVolume()
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SetMusicVolume();
        }
    #endregion
}
