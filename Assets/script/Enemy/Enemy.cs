using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class Enemy : ScriptableObject
{
    public EnemyAction actionForThisTurn;

    [Header("Stats")]
    public int health;
    public int damage;
    public int maxHealth;
    public int defence;
    public EnemyDifficulty difficulty;

    [Header("Ability amounts")]
    public int healAmount;
    public int defenceAmount;

    [Header("Action Sprites")]
    public Sprite attackSprite;
    public Sprite defenceSprite;
    public Sprite abilitySprite;
    
    public enum EnemyAction
    {
        Attack,
        Defend,
        Heal,
    }
    public enum EnemyDifficulty
    {
        Easy,
        Medium,
        Hard
    }
    public void SetDifficulty()
    {
        switch (difficulty)
        {
            case EnemyDifficulty.Easy:
                return;
                case EnemyDifficulty.Medium:
                    return;
                case EnemyDifficulty.Hard:
                return;
        }
    }
}
