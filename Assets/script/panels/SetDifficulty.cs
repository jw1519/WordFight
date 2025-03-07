using System.Collections;
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
                
            }
        }
        GameManager.instance.BeginTurn();
    }
}
