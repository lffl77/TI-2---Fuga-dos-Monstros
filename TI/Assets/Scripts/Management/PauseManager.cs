using UnityEngine;

public class PauseManager : MonoBehaviour {
    private GameObject pauseGame;

    public static PauseManager pInstance;

    private void Awake() {
        if(pInstance == null) 
        {
            pInstance = this;
        }else
        {
            Destroy(this.gameObject);
        }
        pauseGame = GameObject.FindGameObjectWithTag("Pause");
        pauseGame.SetActive(false);
    }

    public void Pause()
    {
        pauseGame.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Despausar()
    {
        pauseGame.SetActive(false);
        Time.timeScale = 1f;
    }
}