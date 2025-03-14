using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : BasePanel
{
    Enemy.EnemyDifficulty difficulty;
    SetDifficulty setDifficulty;

    public void Awake()
    {
        setDifficulty = gameObject.GetComponent<SetDifficulty>();
        OpenPanel();
    }
    public void Easy()
    {
        difficulty = Enemy.EnemyDifficulty.Easy;
        setDifficulty.SetUp(difficulty);
        ClosePanel();
    }
    public void Medium()
    {
        difficulty = Enemy.EnemyDifficulty.Medium;
        setDifficulty.SetUp(difficulty);
        ClosePanel();
    }
    public void Hard()
    {
        difficulty = Enemy.EnemyDifficulty.Hard;
        setDifficulty.SetUp(difficulty);
        ClosePanel();
    }
}
