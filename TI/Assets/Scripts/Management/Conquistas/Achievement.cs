using UnityEngine;

[System.Serializable]
public class Achievement
{
    public string name;
    public string description;
    public bool isCompleted;
    public int scoreRequired; // Pontuação necessária para desbloquear a conquista

    public Achievement(string name, string description, int scoreRequired = 0)
    {
        this.name = name;
        this.description = description;
        this.isCompleted = false;
        this.scoreRequired = scoreRequired;
    }
}