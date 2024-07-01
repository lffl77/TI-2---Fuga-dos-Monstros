using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static Score scInstance;

    private string atualScene;

    #region VariaveisConquistas
    private List<Achievement> achievements = new List<Achievement>();
    private string filePath;
    public int currentScore;
    public string currentPlayerName;
    #endregion 
    
    void Start()
    {
        if (Instance == null)
            Instance = this;

        atualScene = SceneManager.GetActiveScene().name;

        //Caminho das conquistas
        filePath = Path.Combine(Application.persistentDataPath, "achievements.json");
        LoadAchievements();

        //Conquistas
        AddAchievement("De seus primeiros passos", "Corra por 500M (PARTIDA ÚNICA)", 100);
        AddAchievement("Corredor de bairro", "Corra por 1KM (PARTIDA ÚNICA)", 1000);
        AddAchievement("Maratonista", "Corra por 5KM (PARTIDA ÚNICA)", 5000);
        AddAchievement("Run Forrest, Run!", "Corra por 10KM (PARTIDA ÚNICA)", 10000);
    }

    #region InteracoesUI
    public void MenuConfigActive()
    {
        SceneManager.LoadScene("Config");
    }

    public void MenuCreditsActive()
    {
        SceneManager.LoadScene("Credits");
    }

    public void MenuStartActive()
    {
        SceneManager.LoadScene("Menu");
    }

    public void EntrarConquistas()
    {
        Conquistas.cInstance.conquistasPainel.SetActive(true);
    }

    public void SairConquistas()
    {
        Conquistas.cInstance.conquistasPainel.SetActive(false);
    }

    public void Loja()
    {
        SceneManager.LoadScene("Loja");
    }

    public void SelectFases()
    {
        SceneManager.LoadScene("SelectFases");
    }

    public void SelectCharacter()
    {
        SceneManager.LoadScene("SelectCharacter");
    }

    public void Cemiterio()
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

    public void Pausar()
    {
        PauseManager.pInstance.Pause();
    }

    public void SairPause()
    {
        PauseManager.pInstance.Despausar();
    }
    public void GameOver()
    {
        SceneManager.LoadScene("Die");
    }

    public void Quit()
    {
        Application.Quit();
    }
    #endregion

    #region Conquistas
    public void AddAchievement(string name, string description, int scoreRequired = 0)
    {
        achievements.Add(new Achievement(name, description, scoreRequired));
        SaveAchievements();
    }

    public void CompleteAchievement(string name) //Completa sua conquista
    {
        Achievement achievement = achievements.Find(a => a.name == name);
        if (achievement != null && !achievement.isCompleted)
        {
            achievement.isCompleted = true;
            SaveAchievements();
            Debug.Log($"Conquista '{name}' adquirida!");
        }
    }

    public bool IsAchievementCompleted(string name) //Verifica se ja está completada
    {
        Achievement achievement = achievements.Find(a => a.name == name);
        Debug.Log("Conquista já foi adquirida");
        return achievement != null && achievement.isCompleted;
    }

    private void SaveAchievements() //Salva suas conquistas
    {
        string json = JsonUtility.ToJson(new AchievementList(achievements));
        File.WriteAllText(filePath, json);
    }

    private void LoadAchievements() //Carrega suas conquistas
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            AchievementList achievementList = JsonUtility.FromJson<AchievementList>(json);
            achievements = achievementList.achievements;
        }
    }

    public void AddScore(int points) //Adiciona pontos para conseguir a conquista
    {
        currentScore += points;
        CheckScoreAchievements();
    }

    // Verifica se há conquistas a serem desbloqueadas com base na pontuação
    private void CheckScoreAchievements()
    {
        foreach (var achievement in achievements)
        {
            if (!achievement.isCompleted && currentScore >= achievement.scoreRequired && achievement.scoreRequired > 0)
            {
                CompleteAchievement(achievement.name);
            }
        }
    }
    #endregion
}
