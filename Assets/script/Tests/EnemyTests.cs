using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class EnemyTests
{
    private Enemy enemy;

    [SetUp]
    public void SetUp()
    {
        GameObject enemyObject = new GameObject();
        enemy = enemyObject.AddComponent<SetEnemy>().enemy;
        enemy.health = 100;
        enemy.defence = 0;
    }
    [Test]
    public void Enemy_TakesDamage_ReduceHealth()
    {
        //act
        enemy.TakeDamage(10);

        //assert
        Assert.AreEqual(90, enemy.health);
    }
    [Test]
    public void Enemy_TakesDamage_ReduceDefence()
    {
        enemy.defence = 10;
        //act
        enemy.TakeDamage(5);

        //assert
        Assert.AreEqual(5, enemy.defence);
        Assert.AreEqual(100, enemy.health);
    }
    [Test]
    public void Enemy_TakesDamage_ReduceDefence_ReduceHealth()
    {
        enemy.defence = 5;
        //act
        enemy.TakeDamage(10);

        //assert
        Assert.Zero(enemy.defence);
        Assert.AreEqual(95, enemy.health);
    }
}
