using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : MonoBehaviour
{
    public List<Enemy> enemyList;
    Enemy.EnemyDifficulty difficulty;

    private void Awake()
    {
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
        SetUp();
    }
    public void Medium()
    {
        difficulty = Enemy.EnemyDifficulty.Medium;
        SetUp();
    }
    public void Hard()
    {
        difficulty = Enemy.EnemyDifficulty.Hard;
        SetUp();
    }
    public void SetUp()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == difficulty)
            {
                FindFirstObjectByType<SetEnemy>().enemy = Instantiate(enemy);
            }
        }
        SetHealth.instance.UpdateEnemyHealth();
        GameManager.instance.BeginTurn();
        ClosePanel();
    }

}
