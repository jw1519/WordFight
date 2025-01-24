using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseCards : MonoBehaviour
{
    public static UseCards instance;
    private int damage;
    private int defence;

    private Enemy enemy;
    private Player player;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        enemy = FindAnyObjectByType<Enemy>();
        player = FindAnyObjectByType<Player>();
    }
    public void GetCardStats(SetCard card)
    {
        switch (card.card.cardType)
        {
            case Card.CardType.Attack:
                damage = damage + card.card.damageOrDefence;
                return;
            case Card.CardType.Defence:
                defence = defence + card.card.damageOrDefence;
                return;
            case Card.CardType.Ability:
                return;
        }
    }
    public void Attack()
    {
        if (enemy != null)
        {
            enemy.health = enemy.health - damage;
        }
    }
    public void Defence()
    {
        if (player != null)
        {
            player.defence = defence;
        }
    }

}
