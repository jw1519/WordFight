using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : MonoBehaviour
{
    public List<Enemy> enemyList;
    Enemy.EnemyDifficulty difficulty;
    SetDifficulty setDifficulty;

    private void Awake()
    {
        setDifficulty = gameObject.GetComponent<SetDifficulty>();
        OpenPanel();
    }
    public void OpenPanel()
    {
        gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        gameObject.SetActive(false);
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
