using System.Collections.Generic;

[System.Serializable]
public class AchievementList
{
    public List<Achievement> achievements;

    public AchievementList(List<Achievement> achievements)
    {
        this.achievements = achievements;
    }
}