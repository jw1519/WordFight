using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public List<Enemy> enemyList;
    public void SetUp(Enemy.EnemyDifficulty enemyDifficulty)
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == enemyDifficulty)
            {
                FindFirstObjectByType<SetEnemy>().enemy = Instantiate(enemy);
            }
        }
        SetHealth.instance.UpdateEnemyHealth();
        GameManager.instance.BeginTurn();
    }
}
