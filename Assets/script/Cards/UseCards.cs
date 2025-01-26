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
                damage = damage + card.card.damage;
                return;
            case Card.CardType.Defence:
                defence = defence + card.card.damage;
                return;
            case Card.CardType.Ability:
                return;
        }
    }
    public void Attack()
    {
        if (enemy != null)
        {
            if (enemy.health - damage > 0)
            {
                enemy.health = enemy.health - damage;
            }
            else
            {
                enemy.health = 0;
                Debug.Log("Win");
            }
            
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
