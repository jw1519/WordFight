//sets the difficulty of the enemy
using System.Collections.Generic;
using UnityEngine;

public class SetDifficulty : MonoBehaviour
{
    public List<Enemy> enemyList;
    SetEnemy setEnemy;
    public void SetUp(Enemy.EnemyDifficulty enemyDifficulty)
    {
        foreach (Enemy enemy in enemyList)
        {
            if (enemy.difficulty == enemyDifficulty)
            {
                setEnemy = FindAnyObjectByType<SetEnemy>();
                setEnemy.enemy = Instantiate(enemy);
                setEnemy.enemyUI.UpdateHealth(setEnemy.enemy);
                setEnemy.SetEnemySprite(enemy.enemySprite);
            }
        }
        GameManager.instance.BeginTurn();
    }
}
