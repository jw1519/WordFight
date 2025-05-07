using UnityEngine;
using NUnit.Framework;

public class PlayerTests
{
    private Player player;

    [SetUp]
    public void SetUp()
    {
        GameObject playerObject = new GameObject();
        player = playerObject.AddComponent<Player>();
        player.PlayerSO.maxHealth = 100;
        player.PlayerSO.health = 100;
        player.PlayerSO.defence = 0;
    }
    [Test]
    public void Player_TakesDamage_ReduceHealth()
    {
        //act
        player.PlayerSO.TakeDamage(10);

        //assert
        Assert.AreEqual(90, player.PlayerSO.health);
    }

    [Test]
    public void Player_TakesDamage_ReduceDefence()
    {
        player.PlayerSO.defence = 10;
        //act
        player.PlayerSO.TakeDamage(5);

        //assert
        Assert.AreEqual(5, player.PlayerSO.defence);
        Assert.AreEqual(100, player.PlayerSO.health);
    }
    [Test]
    public void Player_TakesDamage_ReduceDefence_ReduceHealth()
    {
        player.PlayerSO.defence = 5;
        //act
        player.PlayerSO.TakeDamage(10);

        //assert
        Assert.Zero(player.PlayerSO.defence);
        Assert.AreEqual(95, player.PlayerSO.health);
    }
}
