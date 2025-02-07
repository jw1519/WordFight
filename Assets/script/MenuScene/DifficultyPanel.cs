using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyPanel : MonoBehaviour
{
    public List<Enemy> enemyList;
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
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == Enemy.EnemyDifficulty.Easy)
            {
                FindFirstObjectByType<SetEnemy>().enemy = enemy;
            }
        }
    }
    public void Medium()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == Enemy.EnemyDifficulty.Medium)
            {
                FindFirstObjectByType<SetEnemy>().enemy = enemy;
            }
        }
    }
    public void Hard()
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == Enemy.EnemyDifficulty.Hard)
            {
                FindFirstObjectByType<SetEnemy>().enemy = enemy;
            }
        }
    }

}
