using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEngine.TestTools;

public class PlayerTests
{
    private Player player;

    [SetUp]
    public void SetUp()
    {
        GameObject playerObject = new GameObject();
        player = playerObject.AddComponent<Player>();
        player.maxHealth = 100;
        player.health = 100;
        player.defence = 0;
    }
    [Test]
    public void Player_TakesDamage_ReduceHealth()
    {
        //act
        player.TakeDamage(10);

        //assert
        Assert.AreEqual(90, player.health);
    }

    [Test]
    public void Player_TakesDamage_ReduceDefence()
    {
        player.defence = 10;
        //act
        player.TakeDamage(5);

        //assert
        Assert.AreEqual(5, player.defence);
        Assert.AreEqual(100, player.health);
    }
    [Test]
    public void Player_TakesDamage_ReduceDefence_ReduceHealth()
    {
        player.defence = 5;
        //act
        player.TakeDamage(10);

        //assert
        Assert.Zero(player.defence);
        Assert.AreEqual(95, player.health);
    }
}
